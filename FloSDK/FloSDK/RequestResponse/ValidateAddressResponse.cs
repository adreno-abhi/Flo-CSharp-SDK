using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloSDK.RequestResponse
{
    class ValidateAddressResponse
    {
        public bool isvalid { get; set; }
        public string address { get; set; }
        public bool ismine { get; set; }
        public bool isscript { get; set; }
        public string pubkey { get; set; }
        public bool iscompressed { get; set; }
        public string account { get; set; }
        public string scriptPubKey { get; set; }
        public string iswatchonly { get; set; }
        public string timestamp { get; set; }

    }
}
