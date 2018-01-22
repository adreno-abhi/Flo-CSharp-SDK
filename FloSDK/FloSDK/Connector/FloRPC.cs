//Author : Abhijeet Das Gupta

//MIT License
//Copyright(c) 2018 Abhijeet
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


using FloSDK.Exceptions;
using FloSDK.RequestResponse;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace FloSDK.Connector
{
    //FLO Blockchain RPC Connector Class Library for connecting to local / remote FLO wallet.
    //Can be referenced into any C# Project to extend the RPC Call functionality to FLO wallet.

    public class FloRPC
    {
        static HttpWebRequest webRequest;

        //Constructor to initialize FLO wallet username, password, URL of FLO wallet and RPC port of the wallet
        public FloRPC(string username, string password, string wallet_url, string wallet_port)
        {
            webRequest = (HttpWebRequest)WebRequest.Create(wallet_url+":"+wallet_port);
            webRequest.Credentials = new NetworkCredential(username, password);
            SetBasicAuthHeader(webRequest, username, password);
            webRequest.ContentType = "application/json-rpc";
            webRequest.Method = "POST";
            webRequest.Proxy = null;
            
        }

        //Library Method used to make RPC Calls to FLO wallet.

        public string MakeRequest(string method, params object[] parameters)
        {
            string json;
            var jsonRpcRequest = new JsonRpcRequest(1, method.ToString(), parameters);            
            
            var byteArray = jsonRpcRequest.GetBytes();
            webRequest.ContentLength = jsonRpcRequest.GetBytes().Length;

            try
            {
                using (var dataStream = webRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Dispose();
                }
            }
            catch (Exception exception)
            {
                throw new RpcException("There was a problem sending the request to the wallet", exception);
            }

            try
            {
                

                using (var webResponse = webRequest.GetResponse())
                {
                    using (var stream = webResponse.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            var result = reader.ReadToEnd();
                            reader.Dispose();
                            json = result;
                        }
                    }
                }
                return json;
                //var rpcResponse = JsonConvert.DeserializeObject<JsonRpcResponse<T>>(json);
                //return rpcResponse.Result;
            }
            catch (WebException webException)
            {
                #region RPC Internal Server Error (with an Error Code)

                var webResponse = webException.Response as HttpWebResponse;

                if (webResponse != null)
                {
                    switch (webResponse.StatusCode)
                    {
                        case HttpStatusCode.InternalServerError:
                            {
                                using (var stream = webResponse.GetResponseStream())
                                {
                                    if (stream == null)
                                    {
                                        throw new RpcException("The RPC request was either not understood by the server or there was a problem executing the request", webException);
                                    }

                                    using (var reader = new StreamReader(stream))
                                    {
                                        var result = reader.ReadToEnd();
                                        reader.Dispose();

                                        try
                                        {
                                            var jsonRpcResponseObject = JsonConvert.DeserializeObject<JsonRpcResponse<object>>(result);

                                            var internalServerErrorException = new RpcInternalServerErrorException(jsonRpcResponseObject.Error.Message, webException)
                                            {
                                                RpcErrorCode = jsonRpcResponseObject.Error.Code
                                            };

                                            throw internalServerErrorException;
                                        }
                                        catch (JsonException)
                                        {
                                            throw new RpcException(result, webException);
                                        }
                                    }
                                }
                            }

                        default:
                            throw new RpcException("The RPC request was either not understood by the server or there was a problem executing the request", webException);
                    }
                }

                #endregion

                #region RPC Time-Out

                if (webException.Message == "The operation has timed out")
                {
                    throw new RpcRequestTimeoutException(webException.Message);
                }

                #endregion

                throw new RpcException("An unknown web exception occured while trying to read the JSON response", webException);
            }
            catch (JsonException jsonException)
            {
                throw new RpcResponseDeserializationException("There was a problem deserializing the response from the wallet", jsonException);
            }
            catch (ProtocolViolationException protocolViolationException)
            {
                throw new RpcException("Unable to connect to the server", protocolViolationException);
            }
            catch (Exception exception)
            {
                var queryParameters = jsonRpcRequest.Parameters.Cast<string>().Aggregate(string.Empty, (current, parameter) => current + (parameter + " "));
                throw new Exception($"A problem was encountered while calling MakeRpcRequest() for: {jsonRpcRequest.Method} with parameters: {queryParameters}. \nException: {exception.Message}");
            }
        }


        private static void SetBasicAuthHeader(WebRequest webRequest, string username, string password)
        {
            var authInfo = username + ":" + password;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            webRequest.Headers["Authorization"] = "Basic " + authInfo;
        }



    }
}
