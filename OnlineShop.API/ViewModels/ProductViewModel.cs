using OnlineShop.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.API.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        
        public CategoryViewModel Category { get; set; }

        public int CategoryId { get; set; }
    }
}
