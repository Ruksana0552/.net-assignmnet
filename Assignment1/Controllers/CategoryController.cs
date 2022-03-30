using Assignment1.Models;
using Assignment1.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategory _category;
        public CategoryController(ICategory category)
        {
            _category = category;
        }
        static List<Category> category = new List<Category>
            {new Category(){CategoryId=1,CategoryName="Electronics"},
                new Category(){CategoryId=1,CategoryName="Automobiles"}
            };
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Add(Category cat)
        {
            _logger.LogInformation("category is getting added");
            category.Add(cat);
            return Ok();
        }


        [HttpGet]
        [Route("Read")]
        public List<Category> Get()
        {
            _logger.LogInformation("retreiving all categories");
            return category;
        }

        [HttpGet]
        [Route("find")]
        public IActionResult GetById(int id)
        {
            var res = category.FirstOrDefault(x => x.CategoryId == id);
            _logger.LogInformation("retreiving product by id");
            if (res == null)
            {
                return BadRequest("prodcut not found");
            }
            else
                return Ok(res);

        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(Category cat)
        {
            _logger.LogInformation("updating product");
            var res = category.FirstOrDefault(x => x.CategoryId == cat.CategoryId);
            res.CategoryId = cat.CategoryId;
            res.CategoryName = cat.CategoryName;
           
            return Ok();
        }
        
        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("deleting ");
            category.RemoveAll(p => p.CategoryId== id);

            return Ok();
        }

        [HttpPost]
        [Route("AddCategory")]
        public bool AddCategory(Category category)
        {
            return _category.Add(category);
        }
        
        
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Category> GetAllCategory()
        {
            return _category.GetAll();
        }

        
        [HttpGet]
        [Route("GetCategoryById/{id}")]
        public Category Get(int id)
        {
            return _category.Get(id);
        }


        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public bool DeleteCategory(int id)
        {
            return _category.Delete(id);
        }


        [HttpPut]
        [Route("UpdateCategory")]
        public bool UpdateCategory(Category category)
        {
            return _category.Update(category);
        }
    }
}