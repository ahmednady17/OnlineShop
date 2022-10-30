using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.ViewModels;
using OnlineShop.Domain.IServices;
using OnlineShop.Domain.Models;
using OnlineShop.Domain.Repositories;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService CategoryService;
        IMapper mapper;
        public CategoryController(ICategoryService CategoryService, IMapper mapper)
        {
            this.CategoryService = CategoryService;
            this.mapper = mapper;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get()
        {
            var categories = CategoryService.GetCategories();
            if (categories != null) 
            {
                var categoryViewModels = mapper.Map<IEnumerable<Category>,IEnumerable <CategoryViewModel>>(categories);

                return Ok(categoryViewModels);
            }
            return BadRequest("No records found");
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = CategoryService.GetById(id);
            if(category != null)
            {
                var categoryViewModel = mapper.Map<Category, CategoryViewModel>(category);

                return Ok(categoryViewModel);
            }
            return BadRequest("No records found");
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] CategoryViewModel categoryViewModel)
        {
            var category = mapper.Map<CategoryViewModel, Category>(categoryViewModel);
            CategoryService.Create(category);
            return Ok("Record created");
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            CategoryService.Update(id,category);
            return Ok("Record updated");
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromBody] Category category)
        {
            CategoryService.Delete(id,category);
            return Ok("Record deleted");
        }
    }
}
