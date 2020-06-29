//Author : Abhijeet Das Gupta

//MIT License
//Copyright(c) 2018 Abhijeet
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using FloSDK.Exceptions;
using FloSDK.Methods;
using FloSDK.RequestResponse;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;

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
                //string toaddr = "oTw4kEvB3MWrN97ujWb6JAs3ye574DvuKV";
                //string fromaddr = "oWVv5huYoVsicv9wLqDSt9hKTYERchm2DY";
                //string response = Call_Service_Get("http://localhost:53722/FloAPI.svc/listunspentbyaddress/"+ fromaddr);
                //JObject objapi = JObject.Parse(response);
                //JArray arrunspent = JArray.Parse(objapi["result"].ToString());
                //decimal amtosent = 2.65m;
                //decimal fee = 0.0001m;
                //decimal bal = 0.0m;

                

                //CreateRawTransactionRequest req1 = new CreateRawTransactionRequest();
                //List<CreateRawTransactionInput> inputs1 = new List<CreateRawTransactionInput>();

                //foreach (JObject o in arrunspent.Children<JObject>())
                //{
                //    CreateRawTransactionInput input1 = new CreateRawTransactionInput();
                //    string tid = o["txid"].ToString();
                //    string vout = o["vout"].ToString();
                //    string scriptPubKey = o["scriptPubKey"].ToString();
                //    decimal amt = Convert.ToDecimal(o["amount"].ToString());
                //    input1.txid = tid;
                //    input1.vout = Convert.ToInt32(vout);
                //    input1.scriptPubKey = scriptPubKey;
                //    inputs1.Add(input1);

                //    bal += amt;
                //    if(bal >= (amtosent+fee))
                //    {
                //        break;
                //    }

                //}
                //decimal change = bal - (amtosent + fee);
                //Dictionary<string, decimal> output1 = new Dictionary<string, decimal>();
                //output1.Add(toaddr, amtosent);
                //output1.Add(fromaddr, change);

                //req1.Inputs = inputs1;
                //req1.Outputs = output1;
                //req1.floData = "Test Raw Transaction API";
                //req1.locktime = 0;
                //req1.replaceable = false;
                //string rawreqjson = JsonConvert.SerializeObject(req1);

                //string rawresp = Call_Service_Post(rawreqjson, "http://localhost:53722/FloAPI.svc/createrawtransaction","text/plain");

                //JObject objraw1 = JObject.Parse(rpc.CreateRawTransaction(req1));

                //string rawHex1 = "";

                //if (string.IsNullOrEmpty(objraw1["error"].ToString()))
                //{
                //    Console.WriteLine("Raw Transaction : " + objraw1["result"]);
                //    rawHex1 = objraw1["result"].ToString();
                //}
                //else
                //{
                //    Console.WriteLine("Raw Transaction Error : " + objraw1["error"]);
                //}

                //string responsepriv = Call_Service_Get("http://localhost:53722/FloAPI.svc/dumpprivkey/" + fromaddr);
                //JObject objpriv = JObject.Parse(responsepriv);
                //string privkey1 = objpriv["result"].ToString();
                //List<string> privkeys1 = new List<string>();
                //privkeys1.Add(privkey1);


                //SignRawTransactionRequest signreq1 = new SignRawTransactionRequest();
                //signreq1.Inputs = inputs1;
                //signreq1.PrivateKeys = privkeys1;
                //signreq1.RawTransactionHex = rawHex1;
                //signreq1.SigHashType = "ALL";

                //string signjson = JsonConvert.SerializeObject(signreq1);

                //string signresp = Call_Service_Post(signjson,"http://localhost:53722/FloAPI.svc/signrawtransaction","application/json");
                //JObject objsign1 = JObject.Parse(signresp);
                //string signHex1 = "";

                //if (string.IsNullOrEmpty(objsign1["error"].ToString()))
                //{
                //    Console.WriteLine("Sign Raw Transaction : " + objsign1["result"]);
                //    signHex1 = objsign1["result"]["hex"].ToString();
                //}
                //else
                //{
                //    Console.WriteLine("Sign Raw Transaction Error : " + objsign1["error"]);
                //}

                //SendRawTransactionRequest sendreq = new SendRawTransactionRequest();
                //sendreq.signedHex = signHex1;
                //string sendreq1 = JsonConvert.SerializeObject(sendreq);

                //string sendresp1 = Call_Service_Post(sendreq1,"http://localhost:53722/FloAPI.svc/sendrawtransaction","application/json");
                //JObject objsend1 = JObject.Parse(sendresp1);

                //string txid = "";

                //if (string.IsNullOrEmpty(objsend1["error"].ToString()))
                //{
                //    Console.WriteLine("Sign Raw Transaction : " + objsend1["result"]);
                //    txid = objsend1["result"].ToString();
                //}
                //else
                //{
                //    Console.WriteLine("Sign Raw Transaction Error : " + objsend1["error"]);
                //}







                JArray jarrlu = new JArray();
                jarrlu.Add("");
                //jarrlu.Add("oHQMHm1eFz3PLgTPWPcYYDNvrB4G241Atd");
                //List Unspent
                JObject objlu = JObject.Parse(rpc.ListUnspent(jarrlu));

                if (string.IsNullOrEmpty(objlu["error"].ToString()))
                {
                    Console.WriteLine("Get Info : " + objlu["result"]);
                }
                else
                {
                    Console.WriteLine("Get Info Error : " + objlu["error"]);
                }

                CreateRawTransactionRequest req = new CreateRawTransactionRequest();
                CreateRawTransactionInput input = new CreateRawTransactionInput();
                input.txid = "5b30f0bf684b90ccc2a3f8cef896b0ed155c9b785fbaf9fca1c1272dc40af4bd";
                input.vout = 0;
                input.scriptPubKey = "76a914ac73b43a12d4ef3a2e71384ae3e35460cf4e91df88ac";
                List<CreateRawTransactionInput> inputs = new List<CreateRawTransactionInput>();
                inputs.Add(input);

                Dictionary<string, decimal> output = new Dictionary<string, decimal>();
                output.Add("oJsvAWvNWZ1jk3fV1BpaWHR3wPrYVaVxwZ", 1.0m);
                output.Add("oYbD4joh3G6d3k3wKbFtBQfgq9BPFxzWPn", 181.4795m);

                req.Inputs = inputs;
                req.Outputs = output;
                req.floData = "Test Raw Transaction";
                req.locktime = 0;
                req.replaceable = false;
                JObject objraw = JObject.Parse(rpc.CreateRawTransaction(req));

                string rawHex = "";

                if (string.IsNullOrEmpty(objraw["error"].ToString()))
                {
                    Console.WriteLine("Raw Transaction : " + objraw["result"]);
                    rawHex = objraw["result"].ToString();
                }
                else
                {
                    Console.WriteLine("Raw Transaction Error : " + objraw["error"]);
                }

                string privkey = "cTd24uWL7Sb6KsJXZzwBQR3mkyg2baEzHJNEhkgBmXPpFxy1Ypf9";
                List<string> privkeys = new List<string>();
                privkeys.Add(privkey);

                SignRawTransactionRequest signreq = new SignRawTransactionRequest();
                signreq.Inputs = inputs;
                signreq.PrivateKeys = privkeys;
                signreq.RawTransactionHex = rawHex;
                signreq.SigHashType = "ALL";

                JObject objsign = JObject.Parse(rpc.SignRawTransaction(signreq));

                string signHex = "";

                if (string.IsNullOrEmpty(objsign["error"].ToString()))
                {
                    Console.WriteLine("Sign Raw Transaction : " + objsign["result"]);
                    signHex = objsign["result"]["hex"].ToString();
                }
                else
                {
                    Console.WriteLine("Sign Raw Transaction Error : " + objsign["error"]);
                }

                JObject objsend = JObject.Parse(rpc.SendRawTransaction(signHex));
                string txid1 = "";

                if (string.IsNullOrEmpty(objsend["error"].ToString()))
                {
                    Console.WriteLine("Sign Raw Transaction : " + objsend["result"]);
                    txid1 = objsend["result"].ToString();
                }
                else
                {
                    Console.WriteLine("Sign Raw Transaction Error : " + objsend["error"]);
                }



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

                obj = JObject.Parse(rpc.Preciousblock("31300e805d4f949e455f20f045162290c920b76e14ec6e614c2c8d5bd4fe119e"));

                if (string.IsNullOrEmpty(obj["error"].ToString()))
                {
                    Console.WriteLine("Get Memory Info : " + obj["result"]);
                }
                else
                {
                    Console.WriteLine("Get Memory Info Error : " + obj["error"]);
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

                //Test

                var jsonObject = new JObject();
                jsonObject.Add("oQDkguVz7CW2eEYCWD2G636tWCg23YcnRx", 1.2);
                jsonObject.Add("oXRrzwxUMcpxHCQWP4T1MQAocudWDzL1UJ", 0.2);

                var job1 = new JObject();
                var job2 = new JObject();
                job1.Add("txid", "b1aa06d72323ae923784d80ebb890c286d963d37901d73806fa2a4fff91865f3");
                job1.Add("vout", 1);
                job2.Add("txid", "b1aa06d72323ae923784d80ebb890c286d963d37901d73806fa2a4fff91865f4");
                job2.Add("vout", 2);

                //create raw transaction
                var jarr = new JArray();
                jarr.Add(job1);
                jarr.Add(job2);

                //obj = JObject.Parse(rpc.CreateRawTransaction(jarr, jsonObject));

                //if (string.IsNullOrEmpty(obj["error"].ToString()))
                //{
                //    Console.WriteLine("Create Raw Transaction : " + obj["result"]);
                //}
                //else
                //{
                //    Console.WriteLine("Error : " + obj["error"]);
                //}

                //decode raw transaction
                obj = JObject.Parse(rpc.DecodeRawTransaction("0200000002f36518f9ffa4a26f80731d90373d966d280c89bb0ed8843792ae2323d706aab10100000000fffffffff46518f9ffa4a26f80731d90373d966d280c89bb0ed8843792ae2323d706aab10200000000ffffffff02000e2707000000001976a91450a3f1d1f0d046af51cc150a6d4c33b37b7daf3988ac002d3101000000001976a9149fb715b93dac58ff46cdafd43c34762109ca604388ac0000000000"));

                if (string.IsNullOrEmpty(obj["error"].ToString()))
                {
                    Console.WriteLine("Decode Raw Transaction : " + obj["result"]);
                }
                else
                {
                    Console.WriteLine("Error : " + obj["error"]);
                }

                //create multi sig
                jarr = new JArray();
                jarr.Add("oYbD4joh3G6d3k3wKbFtBQfgq9BPFxzWPn");
                jarr.Add("oJsvAWvNWZ1jk3fV1BpaWHR3wPrYVaVxwZ");

                obj = JObject.Parse(rpc.AddMultisigAddress(2, jarr));

                if (string.IsNullOrEmpty(obj["error"].ToString()))
                {
                    Console.WriteLine("Add Multisig : " + obj["result"]);
                }
                else
                {
                    Console.WriteLine("Error : " + obj["error"]);
                }



                //obj = JObject.Parse(rpc.SendMany("AbhijeetTest", jsonObject));

                //if (string.IsNullOrEmpty(obj["error"].ToString()))
                //{
                //    Console.WriteLine("Send To Many : " + obj["result"]);
                //}
                //else
                //{
                //    Console.WriteLine("Error : " + obj["error"]);
                //}


                //Get Wallet Info
                obj = JObject.Parse(rpc.SubmitBlock("123456ffggg"));

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

        public static string Call_Service_Post(string req, string url, string contenttype)
        {
            string resultData = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ProtocolVersion = HttpVersion.Version11;
                request.ContentType = contenttype;
                string content = req;
                request.ContentLength = content.Length;
                Stream wri = request.GetRequestStream();
                byte[] array = Encoding.UTF8.GetBytes(content);
                wri.Write(array, 0, array.Length);
                wri.Flush();
                wri.Close();
                HttpWebResponse HttpWResp = (HttpWebResponse)request.GetResponse();
                int resCode = (int)HttpWResp.StatusCode;
                StreamReader reader = new StreamReader(HttpWResp.GetResponseStream(), System.Text.Encoding.UTF8);
                resultData = reader.ReadToEnd();
            }
            catch (Exception ex)
            {

            }
            return resultData;
        }

        public static string Call_Service_Get(string url)
        {
            string resultData = "";
            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                resultData = reader.ReadToEnd();

            }
            catch (Exception ex)
            {

            }

            return resultData;
        }


    }
}
