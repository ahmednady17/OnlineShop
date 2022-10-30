using System;
using System.Collections.Generic;
using System.Text;
using OnlineShop.Domain.Communication;
using OnlineShop.Domain.IServices;
using OnlineShop.Domain.Models;
using OnlineShop.Domain.Repositories;
using OnlineShop.InfraStructre;

namespace OnlineShop.Service.Services
{
    public class ProductService : IProductService
    {
        IProduct productRepo;
        public ProductService(IProduct productRepo)
        {
            this.productRepo = productRepo;
        }
        public Product GetById(int id)
        {
            return productRepo.GetById(id);
        }
        
        public IEnumerable<Product> GetProducts()
        {
            return productRepo.GetProducts();
        }
        public IEnumerable<Product> GetProductsByCategory(int id)
        {
            return productRepo.GetProductsByCategory(id);
        }

        public ProductResponse Create(Product product)
        {
            try
            {
                product = productRepo.Create(product);
                return new ProductResponse(product);
            }
            catch(Exception e)
            {
                return new ProductResponse($"An error occured while creating {e.Message}");
            }
        }
        public ProductResponse Update(int id,Product newproduct)
        {
            try
            {
                Product oldProduct = productRepo.GetById(id);
                oldProduct.Name = newproduct.Name;
                oldProduct.Price = newproduct.Price;
                oldProduct.CategoryId = newproduct.CategoryId;
                oldProduct.ImgUrl = newproduct.ImgUrl;
                oldProduct.Quantity = newproduct.Quantity;
                productRepo.Update(oldProduct);
                return new ProductResponse(oldProduct);
            }
            catch(Exception e)
            {
                return new ProductResponse($"An error occured while updating {e.Message}");
            }
        }
        public void Delete(int id,Product product)
        {
            product = productRepo.GetById(id);
            productRepo.Delete(product);
        }
    }
}
