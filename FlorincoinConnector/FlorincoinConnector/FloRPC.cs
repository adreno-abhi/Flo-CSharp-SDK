//Author : Abhijeet Das Gupta

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FlorincoinConnector
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
            webRequest.ContentType = "application/json-rpc";
            webRequest.Method = "POST";
        }

        //Library Method used to make RPC Calls to FLO wallet.
        //Parameters required are RPC method name, client id (optional) and JArray object to pass parameters for RPC methods (if required). 
        //IF no parameter is required null is passed as props
        public dynamic CallFloRPC(string method, string id, JArray props)
        {
            try
            {
                JObject jobj = new JObject();
                jobj.Add(new JProperty("jsonrpc", "1.0"));
                jobj.Add(new JProperty("id", id));
                jobj.Add(new JProperty("method", method));

                if(props !=null)
                {
                    if (props.HasValues)
                    {
                        jobj.Add(new JProperty("params", props));
                    }
                }
                

                string s = JsonConvert.SerializeObject(jobj);
                byte[] byteArray = Encoding.UTF8.GetBytes(s);
                webRequest.ContentLength = byteArray.Length;
                Stream dataStream = webRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse webResponse = webRequest.GetResponse();
                StreamReader reader = new StreamReader(webResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                string resultData = reader.ReadToEnd();


                return resultData;

            }
            catch(Exception ex)
            {
                return "{\"Error\" : \"Error calling RPC method. -- " + ex.ToString()+"\"}";
            }
        }
    }
}
