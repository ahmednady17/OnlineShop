using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Communication
{
    public abstract class BaseResponse<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Result { get; private set; }
        public BaseResponse(T Result)
        {
            Success = true;
            Message = string.Empty;
            this.Result = Result;
        }
        public BaseResponse(string Message)
        {
            Success = false;
            this.Message = Message;
            Result = default;
        }
    }
}
