//Author : Abhijeet Das Gupta

//MIT License
//Copyright(c) 2018 Abhijeet
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using FloSDK.ErrorCodes;
using System;
using System.Runtime.Serialization;

namespace FloSDK.Exceptions
{
    [Serializable]
    public class RpcInternalServerErrorException : Exception
    {
        public RpcInternalServerErrorException()
        {
        }

        public RpcInternalServerErrorException(string customMessage) : base(customMessage)
        {
        }

        public RpcInternalServerErrorException(string customMessage, Exception exception) : base(customMessage, exception)
        {
        }

        public RpcErrorCode? RpcErrorCode { get; set; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("RpcErrorCode", RpcErrorCode, typeof(RpcErrorCode));
            base.GetObjectData(info, context);
        }
    }
}
