using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloSDK.Exceptions
{
    [Serializable]
    public class RpcResponseDeserializationException : Exception
    {
        public RpcResponseDeserializationException()
        {
        }

        public RpcResponseDeserializationException(string customMessage) : base(customMessage)
        {
        }

        public RpcResponseDeserializationException(string customMessage, Exception exception) : base(customMessage, exception)
        {
        }
    }
}
