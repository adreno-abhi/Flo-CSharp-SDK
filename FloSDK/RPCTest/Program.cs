using FloSDK.Exceptions;
using FloSDK.Methods;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;

namespace RPCTest
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

            //Get Info
            try
            {
                //JObject obj = JObject.Parse(rpc.GetTxOut("7c9088b00d3ff2ed71a65712f294f78edefdd9cb5078a3ebd195954d9a88fd9c",1));

                //if (string.IsNullOrEmpty(obj["error"].ToString()))
                //{
                //    Console.WriteLine("Get Info : " + obj["result"]);
                //}
                //else
                //{
                //    Console.WriteLine("Get Info Error : " + obj["error"]);
                //}
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine("Error : " + ex.StackTrace);
                //}

                ////Get Help
                //try
                //{
                //    JObject obj = JObject.Parse(rpc.Help("setgenerate"));

                //    if (string.IsNullOrEmpty(obj["error"].ToString()))
                //    {
                //        Console.WriteLine("Get Help : " + obj["result"]);
                //    }
                //    else
                //    {
                //        Console.WriteLine("Get Help Error : " + obj["error"]);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine("Error : " + ex.StackTrace);
                //}

                //Get DecodedRawTransaction

                JObject obj = JObject.Parse(rpc.DecodeRawTransaction("0100000002d8c8df6a6fdd2addaf589a83d860f18b44872d13ee6ec3526b2b470d42a96d4d000000008b483045022100b31557e47191936cb14e013fb421b1860b5e4fd5d2bc5ec1938f4ffb1651dc8902202661c2920771fd29dd91cd4100cefb971269836da4914d970d333861819265ba014104c54f8ea9507f31a05ae325616e3024bd9878cb0a5dff780444002d731577be4e2e69c663ff2da922902a4454841aa1754c1b6292ad7d317150308d8cce0ad7abffffffff2ab3fa4f68a512266134085d3260b94d3b6cfd351450cff021c045a69ba120b2000000008b4830450220230110bc99ef311f1f8bda9d0d968bfe5dfa4af171adbef9ef71678d658823bf022100f956d4fcfa0995a578d84e7e913f9bb1cf5b5be1440bcede07bce9cd5b38115d014104c6ec27cffce0823c3fecb162dbd576c88dd7cda0b7b32b0961188a392b488c94ca174d833ee6a9b71c0996620ae71e799fc7c77901db147fa7d97732e49c8226ffffffff02c0175302000000001976a914a3d89c53bb956f08917b44d113c6b2bcbe0c29b788acc01c3d09000000001976a91408338e1d5e26db3fce21b011795b1c3c8a5a5d0788ac0000000"));

                if (string.IsNullOrEmpty(obj["error"].ToString()))
                {
                    Console.WriteLine("Get Decode Raw Transaction : " + obj["result"]);
                }
                else
                {
                    Console.WriteLine("Get Decode Raw Transaction Error : " + obj["error"]);
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
