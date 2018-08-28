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

                obj = JObject.Parse(rpc.AddMultisigAddress(2,jarr));

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
    }
}
