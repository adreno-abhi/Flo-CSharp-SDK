//Author : Abhijeet Das Gupta

//MIT License
//Copyright(c) 2018 Abhijeet
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using FloSDK.Exceptions;
using FloSDK.Methods;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;

namespace FloSdkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = ConfigurationManager.AppSettings.Get("username");
            string password = ConfigurationManager.AppSettings.Get("password");
            string wallet_url = ConfigurationManager.AppSettings.Get("wallet_url");
            string wallet_port = ConfigurationManager.AppSettings.Get("wallet_port");


            RpcMethods rpc = new RpcMethods(username, password, wallet_url, wallet_port);


            try
            {
                //Get Info
                JObject obj = JObject.Parse(rpc.GetInfo());

                if (string.IsNullOrEmpty(obj["error"].ToString()))
                {
                    Console.WriteLine("Get Info : " + obj["result"]);
                }
                else
                {
                    Console.WriteLine("Get Info Error : " + obj["error"]);
                }


                //Get Help

                obj = JObject.Parse(rpc.Help("getinfo"));

                if (string.IsNullOrEmpty(obj["error"].ToString()))
                {
                    Console.WriteLine("Get Help : " + obj["result"]);
                }
                else
                {
                    Console.WriteLine("Get Help Error : " + obj["error"]);
                }

                //Get Balance

                obj = JObject.Parse(rpc.GetBalance(""));

                if (string.IsNullOrEmpty(obj["error"].ToString()))
                {
                    Console.WriteLine("Balance : " + obj["result"]);
                }
                else
                {
                    Console.WriteLine("Get Balance Error : " + obj["error"]);
                }

                //Get Wallet Info
                obj = JObject.Parse(rpc.GetWalletInfo());

                if (string.IsNullOrEmpty(obj["error"].ToString()))
                {
                    Console.WriteLine("Wallet Info : " + obj["result"]);
                }
                else
                {
                    Console.WriteLine("Wallet Info Error : " + obj["error"]);
                }              


            }
            catch (RpcInternalServerErrorException exception)
            {
                var errorCode = 0;
                var errorMessage = string.Empty;

                if (exception.RpcErrorCode.GetHashCode() != 0)
                {
                    errorCode = exception.RpcErrorCode.GetHashCode();
                    errorMessage = exception.RpcErrorCode.ToString();
                }

                Console.WriteLine("[Failed] {0} {1} {2}", exception.Message, errorCode != 0 ? "Error code: " + errorCode : string.Empty, !string.IsNullOrWhiteSpace(errorMessage) ? errorMessage : string.Empty);
            }
            catch (Exception exception)
            {
                Console.WriteLine("[Failed]\n\nPlease check your configuration and make sure that the daemon is up and running and that it is synchronized. \n\nException: " + exception);
            }

            Console.Read();
        }
    }
}
