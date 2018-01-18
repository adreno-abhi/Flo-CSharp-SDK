## FLO Wallet RPC Connector Library in C#
**Author** : Abhijeet Das Gupta

**Version** : 0.0.0.1

**.Net Framework Used** : 4.6.1

**External References Used** : Newtonsoft.Json

(URL : https://www.newtonsoft.com/json)


**Description** - FLO Blockchain RPC Connector Class Library for connecting to local / remote FLO wallet.
Can be referenced into any C# Project to extend the RPC Call functionality to FLO wallet.


**Methods**:

**1. Constructor**: Used to initialize the HttpWebRequest object for making Http calls to the wallet. Parameters include - 
Wallet username, Wallet Password, Wallet URL and Wallet RPC Port.
```C#
        public FloRPC(string username, string password, string wallet_url, string wallet_port)
        {
            webRequest = (HttpWebRequest)WebRequest.Create(wallet_url+":"+wallet_port);
            webRequest.Credentials = new NetworkCredential(username, password);
            webRequest.ContentType = "application/json-rpc";
            webRequest.Method = "POST";
        }
```

**2. CallFloRPC(string method, string id, JArray props)** - Library Method used to make RPC Calls to FLO wallet.
   Parameters required are RPC method name, client id (optional) and JArray object to pass parameters for RPC methods (if required). 
   IF no parameter is required null is passed as props
   ```C#
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
```

Working on implementing this library to make Web APIs that will be able to make available RPC methods to FLO wallet.
Repository for API will be published separately.



