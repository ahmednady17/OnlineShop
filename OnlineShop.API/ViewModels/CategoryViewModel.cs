using OnlineShop.Domain.Models;
using System.Collections.Generic;

namespace OnlineShop.API.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductViewModel> Products { get; set; }


    }
}
