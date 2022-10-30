using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Models;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.InfraStructre.Repositories
{
    public class ProductRepo : IProduct
    {
        Context context;
        public ProductRepo(Context context)
        {
            this.context = context;
        }
        public Product GetById(int id)
        {
            return context.Products.SingleOrDefault(p => p.Id == id);
            
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products.ToList();
        }
        public IEnumerable<Product> GetProductsByCategory(int id)
        {
            return context.Products.Where(p => p.CategoryId == id);
        }

        public Product Create(Product product)
        {
            context.Products.Add(product);
            return product;
        }
        public Product Update(Product product)
        {
            context.Update(product);
            return product ;
        }
        public void Delete(Product product)
        {
            context.Remove(product);
        }
  

    }
}
