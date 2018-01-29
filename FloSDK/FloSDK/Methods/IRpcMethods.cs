//Author : Abhijeet Das Gupta

//MIT License
//Copyright(c) 2018 Abhijeet
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using Newtonsoft.Json.Linq;

namespace FloSDK.Methods
{
    interface IRpcMethods
    {
        //== Control ==
        string GetInfo();
        string Help(string command);

        //==Blockchain==
        string GetBestBlockHash();
        string GetBlock(string hash);
        string GetBlockChainInfo();
        string GetBlockCount();
        string GetBlockHash(int block);
        string GetChainTips();
        string GetDifficulty();
        string GetMemPoolInfo();
        string GetRawMemPool();
        string GetTxOut(string txid, int vout);
        string GetTxOutSetInfo();
        string VerifyChain();

        //== Generating ==
        string GetGenerate();
        string GetHashesPerSec();
        string SetGenerate(bool generate);

        //== Mining ==
        string GetBlockTemplate();
        string GetMiningInfo();
        string GetNetworkHashPs();
        string PrioritiseTransaction(string txid, decimal priority, int fee);
        string SubmitBlock(string hexdata); 

        //== Network ==
        string AddNode(string node, string command);
        string GetAddedNodeInfo(bool dns);
        string GetConnectionCount();
        string GetNetTotals();
        string GetNetworkInfo();
        string GetPeerInfo();
        string Ping();

        //== Rawtransactions ==
        string CreateRawTransaction(JArray transactions, JObject addresses);
        string DecodeRawTransaction(string hexstring);
        string DecodeScript(string hex);
        string GetRawTransaction(string txid);
        string SendRawTransaction(string hexstring);
        string SignRawTransaction(string hexstring);

        //== Util ==
        string CreateMultisig(int nrequired, JArray keys);
        string EstimateFee(int nblocks);
        string EstimatePriority(string nblocks);
        string ValidateAddress(string florincoinaddress);
        string VerifyMessage(string florincoinaddress, string signature, string message);

        //== Wallet ==
        string AddultisigAddress(int nrequired, JArray keysobject);
        string DumpPrivkey(string florincoinaddress);
        string DumpWallet(string filename);
        string EncryptWallet(string passphrase);
        string GetAccount(string florincoinaddress);
        string GetAccountAddress(string account);
        string GetAddressesByAccount(string account);
        string GetBalance(string account);
        string GetNewAddress(string account);
        string GetRawChangeAddress();
        string GetReceivedByAccount(string account);
        string GetReceivedByAddress(string florincoinaddress);
        string GetTransaction(string txid);
        string GetUnconfirmedBalance();
        string GetWalletInfo();
        string ImportAddress(string address);
        string ImportPrivKey(string florincoinprivkey);
        string ImportWallet(string filename);
        string KeypoolRefill();
        string ListAccounts();
        string ListAddressGroupings();
        string ListLockUnspent();
        string ListReceivedByAccount();
        string ListReceivedByAddress();
        string ListSinceBlock();
        string ListTransactions();
        string ListUnspent();
        string LockUnspent(bool unlock, JArray transactions);
        string Move(string fromaccount, string toaccount, decimal amount);
        string SendFrom(string fromaccount, string toflorincoinaddress, decimal amount);
        string SendMany(string fromaccount, JObject addresses);
        string SendToAddress(string florincoinaddress, decimal amount, string comment, string commentto, string txcomment);
        string SetAccount(string florincoinaddress, string account);
        string SetTxFee(decimal amount);
        string SignMessage(string florincoinaddress, string message);

    }
}
