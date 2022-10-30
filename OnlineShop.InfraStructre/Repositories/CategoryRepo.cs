using OnlineShop.Domain.Models;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.InfraStructre.Repositories
{
    public class CategoryRepo : ICategory
    {
        Context context;
        public CategoryRepo(Context context)
        {
            this.context = context;
        }
        public Category GetById(int id)
        {
            return context.Categories.SingleOrDefault(p => p.Id == id);

        }
        public IEnumerable<Category> Getcategories()
        {
            return context.Categories.ToList();
        }

        public Category Create(Category category)
        {
            context.Categories.Add(category);
            return category;
        }
        public Category Update(Category category)
        {
            context.Update(category);
            return category;
        }
        public void Delete(Category category)
        {
            context.Remove(category);
        }
    }
}
