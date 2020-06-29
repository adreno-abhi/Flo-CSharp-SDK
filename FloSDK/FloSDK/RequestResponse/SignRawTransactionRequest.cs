using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloSDK.RequestResponse
{
    public class SignRawTransactionRequest
    {
        public string RawTransactionHex { get; set; }
        public List<CreateRawTransactionInput> Inputs { get; set; }
        public List<string> PrivateKeys { get; set; }
        public string SigHashType { get; set; }
    }
}
