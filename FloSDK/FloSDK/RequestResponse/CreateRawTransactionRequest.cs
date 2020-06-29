using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloSDK.RequestResponse
{
    public class CreateRawTransactionRequest
    {
        public List<CreateRawTransactionInput> Inputs { get; set; }
        public Dictionary<string, decimal> Outputs { get; set; }
        public int locktime { get; set; }
        public bool replaceable { get; set; }
        public string floData { get; set; }
    }

    public class CreateRawTransactionInput
    {
        public string txid { get; set; }
        public int vout { get; set; }
        public string scriptPubKey { get; set; }
    }


}
