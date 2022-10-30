using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Communication
{
    public class CategoryResponse : BaseResponse<Category>
    {
        public CategoryResponse(Category Result) : base(Result)
        {
        }

        public CategoryResponse(string Message) : base(Message)
        {
        }
    }
}
