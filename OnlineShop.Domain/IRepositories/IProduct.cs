using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace OnlineShop.Domain.Repositories
{
    public interface IProduct
    {
        public Product GetById(int id);
        public IEnumerable<Product> GetProducts();
        public IEnumerable<Product> GetProductsByCategory(int id);
        public Product Create(Product product);
        public Product Update(Product product);
        public void Delete(Product product);
        
    }
}
