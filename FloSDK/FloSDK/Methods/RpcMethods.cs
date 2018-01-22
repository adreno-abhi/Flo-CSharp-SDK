﻿//Author : Abhijeet Das Gupta

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
            string resp = conn.MakeRequest("getblock",hash);
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
            string resp = conn.MakeRequest("getblockhash",block);
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
            string resp = conn.MakeRequest("getrawmempool",true);
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
            string resp = conn.MakeRequest("submitblock",hexdata);
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
            string resp = conn.MakeRequest("getaddednodeinfo",dns);
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

        public string DecodeRawTransaction(string hexstring)
        {            
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("decoderawtransaction", hexstring);
            return resp;
        }

        public string DecodeScript(string hex)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("decodescript",hex);
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
            string resp = conn.MakeRequest("sendrawtransaction",hexstring);
            return resp;
        }

        public string SignRawTransaction(string hexstring)
        {
            FloRPC conn = new FloRPC(username, password, wallet_url, wallet_port);
            string resp = conn.MakeRequest("signrawtransaction",hexstring);
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
            string resp = conn.MakeRequest("estimatepriority",nblocks);
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
    }
}