using OnlineShop.Domain.Communication;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.IServices
{
    public interface ICategoryService
    {
        public Category GetById(int id);
        public IEnumerable<Category> GetCategories();
        public CategoryResponse Create(Category category);
        public CategoryResponse Update(int id,Category category);
        public void Delete(int id,Category category);

    }
}
