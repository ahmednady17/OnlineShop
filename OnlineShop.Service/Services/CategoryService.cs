using OnlineShop.Domain.Communication;
using OnlineShop.Domain.IServices;
using OnlineShop.Domain.Models;
using OnlineShop.Domain.Repositories;
using OnlineShop.InfraStructre.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Service.Services
{
    public class CategoryService : ICategoryService
    {
        ICategory categoryRepo;

        public CategoryService(ICategory categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }
        public Category GetById(int id)
        {
            return categoryRepo.GetById(id);
        }

        public IEnumerable<Category> GetCategories()
        {
            return categoryRepo.Getcategories();
        }

        public CategoryResponse Create(Category category)
        {
            try
            {
                categoryRepo.Create(category);
                return new CategoryResponse(category);
            }
            catch(Exception e)
            {
                return new CategoryResponse($"An error occured while creating {e.Message}");
            }
        }
        public CategoryResponse Update(int id,Category newCategory)
        {
            try
            {
                Category oldCategory = categoryRepo.GetById(id);
                oldCategory.Name = newCategory.Name;
                categoryRepo.Update(oldCategory);
                return new CategoryResponse(oldCategory);
            }
            catch(Exception e)
            {
                return new CategoryResponse($"An error occured while updating {e.Message}");
            }
        }
        public void Delete(int id,Category category) 
        { 
        
            category = categoryRepo.GetById(id);
            categoryRepo.Delete(category);
        }
    }
}
