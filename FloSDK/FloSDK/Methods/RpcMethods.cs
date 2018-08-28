//Author : Abhijeet Das Gupta

//MIT License
//Copyright(c) 2018 Abhijeet
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

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
            return resp;
        }

        public string Help(string command)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("help", command);
            return resp;
        }

        public string GetBestBlockHash()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getbestblockhash");
            return resp;
        }

        public string GetBlock(string hash)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getblock", hash);
            return resp;
        }

        public string GetBlockChainInfo()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getblockchaininfo");
            return resp;
        }

        public string GetBlockCount()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getblockcount");
            return resp;
        }

        public string GetBlockHash(int block)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getblockhash", block);
            return resp;
        }

        public string GetChainTips()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getchaintips");
            return resp;
        }

        public string GetDifficulty()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getdifficulty");
            return resp;
        }

        public string GetMemPoolInfo()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getmempoolinfo");
            return resp;
        }

        public string GetRawMemPool()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getrawmempool", true);
            return resp;
        }

        public string GetTxOut(string txid, int vout)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("gettxout", txid, vout);
            return resp;
        }

        public string GetTxOutSetInfo()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("gettxoutsetinfo");
            return resp;
        }

        public string VerifyChain()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("verifychain");
            return resp;
        }

        public string GetGenerate()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getgenerate");
            return resp;
        }

        public string GetHashesPerSec()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("gethashespersec");
            return resp;
        }

        public string SetGenerate(bool generate)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("setgenerate", generate);
            return resp;
        }

        public string GetBlockTemplate()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getblocktemplate");
            return resp;
        }

        public string GetMiningInfo()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getmininginfo");
            return resp;
        }

        public string GetNetworkHashPs()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getnetworkhashps");
            return resp;
        }

        public string PrioritiseTransaction(string txid, decimal priority, int fee)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("prioritisetransaction", priority, fee);
            return resp;
        }

        public string SubmitBlock(string hexdata)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("submitblock", hexdata);
            return resp;
        }

        public string AddNode(string node, string command)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("addnode", node, command);
            return resp;
        }

        public string GetAddedNodeInfo(bool dns)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getaddednodeinfo", dns);
            return resp;
        }

        public string GetConnectionCount()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getconnectioncount");
            return resp;
        }

        public string GetNetTotals()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getnettotals");
            return resp;
        }

        public string GetNetworkInfo()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getnetworkinfo");
            return resp;
        }

        public string GetPeerInfo()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getpeerinfo");
            return resp;
        }

        public string Ping()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("ping");
            return resp;
        }

        public string CreateRawTransaction(JArray transactions, JObject addresses)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("createrawtransaction", transactions, addresses);
            return resp;
        }

        public string DecodeRawTransaction(string hexstring)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("decoderawtransaction", hexstring);
            return resp;
        }

        public string DecodeScript(string hex)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("decodescript", hex);
            return resp;
        }

        public string GetRawTransaction(string txid)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            //Verbose = 1; return as JSON object, verbose = 0; return as string
            string resp = conn.MakeRequest("getrawtransaction", txid, 1);
            return resp;
        }

        public string SendRawTransaction(string hexstring)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("sendrawtransaction", hexstring);
            return resp;
        }

        public string SignRawTransaction(string hexstring)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("signrawtransaction", hexstring);
            return resp;
        }

        public string CreateMultisig(int nrequired, JArray keys)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("createmultisig", nrequired, keys);
            return resp;
        }

        public string EstimateFee(int nblocks)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("estimatefee", nblocks);
            return resp;
        }

        public string EstimatePriority(string nblocks)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("estimatepriority", nblocks);
            return resp;
        }

        public string ValidateAddress(string florincoinaddress)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("validateaddress", florincoinaddress);
            return resp;
        }

        public string VerifyMessage(string florincoinaddress, string signature, string message)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("verifymessage", florincoinaddress, signature, message);
            return resp;
        }

        public string AddMultisigAddress(int nrequired, JArray keysobject)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("addmultisigaddress", nrequired, keysobject);
            return resp;
        }

        public string DumpPrivkey(string florincoinaddress)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("dumpprivkey", florincoinaddress);
            return resp;
        }

        public string DumpWallet(string filename)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("dumpwallet", filename);
            return resp;
        }

        public string EncryptWallet(string passphrase)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("encryptwallet", passphrase);
            return resp;
        }

        public string GetAccount(string florincoinaddress)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getaccount", florincoinaddress);
            return resp;
        }

        public string GetAccountAddress(string account)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getaccountaddress", account);
            return resp;
        }

        public string GetAddressesByAccount(string account)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getaddressesbyaccount", account);
            return resp;
        }
        public string GetBalance(string account)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getbalance", account);
            return resp;
        }

        public string GetNewAddress(string account)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getnewaddress", account);
            return resp;
        }

        public string GetRawChangeAddress()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getrawchangeaddress");
            return resp;
        }

        public string GetReceivedByAccount(string account)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getreceivedbyaccount", account);
            return resp;
        }

        public string GetReceivedByAddress(string florincoinaddress)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getreceivedbyaddress", florincoinaddress);
            return resp;
        }

        public string GetTransaction(string txid)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("gettransaction", txid);
            return resp;
        }

        public string GetUnconfirmedBalance()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getunconfirmedbalance");
            return resp;
        }

        public string GetWalletInfo()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("getwalletinfo");
            return resp;
        }

        public string ImportAddress(string address)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("importaddress ", address);
            return resp;
        }

        public string ImportPrivKey(string florincoinprivkey)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("importprivkey ", florincoinprivkey);
            return resp;
        }

        public string ImportWallet(string filename)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("importwallet", filename);
            return resp;
        }

        public string KeypoolRefill()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("keypoolrefill");
            return resp;
        }

        public string ListAccounts()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("listaccounts");
            return resp;
        }

        public string ListAddressGroupings()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("listaddressgroupings");
            return resp;
        }

        public string ListLockUnspent()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("listlockunspent");
            return resp;
        }
        public string ListReceivedByAccount()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("listreceivedbyaccount");
            return resp;
        }
        public string ListReceivedByAddress()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("listreceivedbyaddress");
            return resp;
        }

        public string ListSinceBlock()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("listsinceblock");
            return resp;
        }

        public string ListTransactions()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("listtransactions");
            return resp;
        }

        public string ListUnspent()
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("listunspent");
            return resp;
        }

        public string LockUnspent(bool unlock, JArray transactions)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("lockunspent", unlock, transactions);
            return resp;
        }

        public string Move(string fromaccount, string toaccount, decimal amount)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("move", fromaccount, toaccount, amount);
            return resp;
        }

        public string SendFrom(string fromaccount, string toflorincoinaddress, decimal amount)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("sendfrom", fromaccount, toflorincoinaddress, amount);
            return resp;
        }

        public string SendMany(string fromaccount, JObject addresses)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("sendmany", fromaccount, addresses);
            return resp;
        }

        //public string SendToAddress(string florincoinaddress, decimal amount, string comment, string commentto, string txcomment)
        //{
        //    FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
        //    string resp = conn.MakeRequest("sendtoaddress", florincoinaddress, amount, comment, commentto, txcomment);
        //    return resp;
        //}

        public string SendToAddress(string address, decimal amount, string comment, string comment_to, bool subtractfeefromamount, bool replaceable, int conf_target, string estimate_mode, string floData)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("sendtoaddress", address, amount, comment, comment_to, subtractfeefromamount, replaceable, conf_target, estimate_mode, floData);
            return resp;
        }

        public string SetAccount(string florincoinaddress, string account)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("setaccount", florincoinaddress, account);
            return resp;
        }

        public string SetTxFee(decimal amount)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("settxfee", amount);
            return resp;
        }

        public string SignMessage(string florincoinaddress, string message)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("signmessage", florincoinaddress, message);
            return resp;
        }
    }
}
