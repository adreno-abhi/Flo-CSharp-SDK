using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloSDK.Exceptions
{
    public class RpcRequestTimeoutException : Exception
    {
        public RpcRequestTimeoutException()
        {
        }

        public RpcRequestTimeoutException(string customMessage) : base(customMessage)
        {
        }

        public RpcRequestTimeoutException(string customMessage, Exception exception) : base(customMessage, exception)
        {
        }
    }
}
