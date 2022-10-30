using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.ViewModels;
using OnlineShop.Domain.Communication;
using OnlineShop.Domain.IServices;
using OnlineShop.Domain.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService productService;
        IMapper mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            var products = productService.GetProducts();
            if (products != null)
            {
                var productViewModels = mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);
                return Ok(productViewModels);
            }
            return BadRequest("No records found");
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = productService.GetById(id);
            if(product != null)
            {
                var productViewModel = mapper.Map<Product,ProductViewModel>(product);
                return Ok(productViewModel);
            }
            return BadRequest("No records found");
        }
        [HttpGet("GetByCategory")]
        public IActionResult GetByCategory([FromQuery] int id)
        {
            var products = productService.GetProductsByCategory(id);
            if (products != null)
            {
                var productViewModels = mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);

                return Ok(productViewModels);
            }
            return BadRequest("No records found");
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductViewModel productViewModel)
        {
            var product = mapper.Map<ProductViewModel, Product>(productViewModel);
            ProductResponse productResponse = productService.Create(product);
            if(productResponse.Success)
            {
                return Ok("Record created");
            }
            return BadRequest("Record creation failed");
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductViewModel productViewModel)
        {
            var product = mapper.Map<ProductViewModel, Product>(productViewModel);
            ProductResponse productResponse = productService.Update(id,product);
            if(productResponse.Success)
            {
                return Ok("Record updated");
            } 
            
            return BadRequest("Record update failed");
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromBody] ProductViewModel productViewModel)
        {
            var product = mapper.Map<ProductViewModel, Product>(productViewModel);
            productService.Delete(id,product);
            return Ok("Record deleted");

        }
    }
}
