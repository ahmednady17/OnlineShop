using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Domain.Repositories
{
    public interface ICategory
    {

        public Category GetById(int id);
       

        public IEnumerable<Category> Getcategories();


        public Category Create(Category category);


        public Category Update(Category category);


        public void Delete(Category category);
        
    }
}
