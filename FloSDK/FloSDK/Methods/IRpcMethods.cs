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
        string GetBlockHash(string block);
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
        string SetGenerate(string generate);

        //== Mining ==
        string GetBlockTemplate();
        string GetMiningInfo();
        string GetNetworkHashPs();
        string PrioritiseTransaction(string txid, string priority, string fee);
        string SubmitBlock(string hexdata); 

        //== Network ==
        string AddNode(string node, string command);
        string GetAddedNodeInfo(string dns);
        string GetConnectionCount();
        string GetNetTotals();
        string GetNetworkInfo();
        string GetPeerInfo();
        string Ping();

        //== Rawtransactions ==
        //TODO: createrawtransaction 
        string DecodeRawTransaction(string hexstring);
        string DecodeScript(string hex);
        string GetRawTransaction(string txid);
        string SendRawTransaction(string hexstring);
        string SignRawTransaction(string hexstring);

        //== Util ==
        //TODO: createmultisig 
        string EstimateFee(string nblocks);
        string EstimatePriority(string nblocks);
        string ValidateAddress(string florincoinaddress);
        string VerifyMessage(string florincoinaddress, string signature, string message);

        //== Wallet ==




    }
}
