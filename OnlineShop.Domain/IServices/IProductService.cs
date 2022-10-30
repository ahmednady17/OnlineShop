using OnlineShop.Domain.Communication;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.IServices
{
    public interface IProductService
    {
        public Product GetById(int id);
        public IEnumerable<Product> GetProducts();
        public IEnumerable<Product> GetProductsByCategory(int id);
        public ProductResponse Create(Product product);
        public ProductResponse Update(int id,Product product);
        public void Delete(int id,Product product);

    }
}
