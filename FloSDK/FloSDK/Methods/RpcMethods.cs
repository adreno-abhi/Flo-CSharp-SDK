using FloSDK.Connector;
using Newtonsoft.Json.Linq;
using System;

namespace FloSDK.Methods
{
    public class RpcMethods : IRpcMethods
    {
        string username = "";
        string password = "";
        string wallet_url = "";
        string wallet_port = "";

        public RpcMethods(string username, string password, string wallet_url, string wallet_port)
        {
            this.username = username;
            this.password = password;
            this.wallet_url = wallet_url;
            this.wallet_port = wallet_port;
        }


        public string GetInfo()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getinfo");
            //string resp = conn.CallFloRPC("getinfo", "", null);
            return resp;
        }

        public string Help(string command)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            JArray props = new JArray();
            props.Add(command);
            string resp = conn.CallFloRPC("help", "", props);
            return resp;
        }

        public string GetBestBlockHash()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.CallFloRPC("getbestblockhash", "", null);
            return resp;
        }

        public string GetBlock(string hash)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            JArray props = new JArray();
            props.Add(hash);
            string resp = conn.CallFloRPC("getblock", "", props);
            return resp;
        }

        public string GetBlockChainInfo()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.CallFloRPC("getblockchaininfo", "", null);
            return resp;
        }

        public string GetBlockCount()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.CallFloRPC("getblockcount", "", null);
            return resp;
        }

        public string GetBlockHash(string block)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            JArray props = new JArray();
            props.Add(Convert.ToInt32(block));
            string resp = conn.CallFloRPC("getblockhash", "", props);
            return resp;
        }

        public string GetChainTips()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.CallFloRPC("getchaintips", "", null);
            return resp;
        }

        public string GetDifficulty()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.CallFloRPC("getdifficulty", "", null);
            return resp;
        }

        public string GetMemPoolInfo()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.CallFloRPC("getmempoolinfo", "", null);
            return resp;
        }

        public string GetRawMemPool()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            JArray props = new JArray();
            props.Add(true);
            string resp = conn.CallFloRPC("getrawmempool", "", props);
            return resp;
        }

        public string GetTxOut(string txid, int vout)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            //JArray props = new JArray();
            //props.Add(txid);
            //props.Add(Convert.ToInt32(vout));
            //string resp = conn.CallFloRPC("gettxout", "", props);
            string resp = conn.MakeRequest("gettxout", txid, vout);
            return resp;
        }

        public string GetTxOutSetInfo()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.CallFloRPC("gettxoutsetinfo", "", null);
            return resp;
        }

        public string VerifyChain()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.CallFloRPC("verifychain", "", null);
            return resp;
        }

        public string GetGenerate()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.CallFloRPC("getgenerate", "", null);
            return resp;
        }

        public string GetHashesPerSec()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.CallFloRPC("gethashespersec", "", null);
            return resp;
        }

        public string SetGenerate(string generate)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            JArray props = new JArray();
            props.Add(Convert.ToBoolean(generate));
            string resp = conn.CallFloRPC("setgenerate", "", props);
            return resp;
        }

        public string GetBlockTemplate()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.CallFloRPC("getblocktemplate", "", null);
            return resp;
        }

        public string GetMiningInfo()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.CallFloRPC("getmininginfo", "", null);
            return resp;
        }

        public string GetNetworkHashPs()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.CallFloRPC("getnetworkhashps", "", null);
            return resp;
        }

        public string PrioritiseTransaction(string txid, string priority, string fee)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            JArray props = new JArray();
            props.Add(txid);
            props.Add(Convert.ToDecimal(priority));
            props.Add(Convert.ToInt32(fee));
            string resp = conn.CallFloRPC("prioritisetransaction", "", props);
            return resp;
        }

        public string SubmitBlock(string hexdata)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            JArray props = new JArray();
            props.Add(hexdata);
            string resp = conn.CallFloRPC("submitblock", "", props);
            return resp;
        }

        public string AddNode(string node, string command)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            JArray props = new JArray();
            props.Add(node);
            props.Add(command);
            string resp = conn.CallFloRPC("addnode", "", props);
            return resp;
        }

        public string GetAddedNodeInfo(string dns)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            JArray props = new JArray();
            props.Add(Convert.ToBoolean(dns));
            string resp = conn.CallFloRPC("getaddednodeinfo", "", props);
            return resp;
        }

        public string GetConnectionCount()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.CallFloRPC("getconnectioncount", "", null);
            return resp;
        }

        public string GetNetTotals()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.CallFloRPC("getnettotals", "", null);
            return resp;
        }

        public string GetNetworkInfo()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.CallFloRPC("getnetworkinfo", "", null);
            return resp;
        }

        public string GetPeerInfo()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.CallFloRPC("getpeerinfo", "", null);
            return resp;
        }

        public string Ping()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.CallFloRPC("ping", "", null);
            return resp;
        }

        public string DecodeRawTransaction(string hexstring)
        {            
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("decoderawtransaction", hexstring);
            //JArray props = new JArray();
            //props.Add(hexstring);
            //string resp = conn.CallFloRPC("decoderawtransaction", "", props);
            return resp;
        }

        public string DecodeScript(string hex)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            JArray props = new JArray();
            props.Add(hex);
            string resp = conn.CallFloRPC("decodescript", "", props);
            return resp;
        }

        public string GetRawTransaction(string txid)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            JArray props = new JArray();
            props.Add(txid);
            //Verbose = 1; return as JSON object, verbose = 0; return as string
            props.Add(1);
            string resp = conn.CallFloRPC("getrawtransaction", "", props);
            return resp;
        }

        public string SendRawTransaction(string hexstring)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            JArray props = new JArray();
            props.Add(hexstring);
            string resp = conn.CallFloRPC("sendrawtransaction", "", props);
            return resp;
        }

        public string SignRawTransaction(string hexstring)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            JArray props = new JArray();
            props.Add(hexstring);
            string resp = conn.CallFloRPC("signrawtransaction", "", props);
            return resp;
        }

        public string EstimateFee(string nblocks)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            JArray props = new JArray();
            props.Add(Convert.ToInt32(nblocks));
            string resp = conn.CallFloRPC("estimatefee", "", props);
            return resp;
        }

        public string EstimatePriority(string nblocks)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            JArray props = new JArray();
            props.Add(Convert.ToInt32(nblocks));
            string resp = conn.CallFloRPC("estimatepriority", "", props);
            return resp;
        }

        public string ValidateAddress(string florincoinaddress)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            JArray props = new JArray();
            props.Add(florincoinaddress);
            string resp = conn.CallFloRPC("validateaddress", "", props);
            return resp;
        }

        public string VerifyMessage(string florincoinaddress, string signature, string message)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            JArray props = new JArray();
            props.Add(florincoinaddress);
            props.Add(signature);
            props.Add(signature);
            string resp = conn.CallFloRPC("verifymessage", "", props);
            return resp;
        }
    }
}
