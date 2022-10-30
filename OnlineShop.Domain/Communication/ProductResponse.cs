using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Communication
{
    public class ProductResponse : BaseResponse<Product>
    {
        public ProductResponse(Product Result) : base(Result)
        {
        }

        public ProductResponse(string Message) : base(Message)
        {
        }
    }
}
