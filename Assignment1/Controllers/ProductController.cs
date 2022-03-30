using Assignment1.Models;
using Assignment1.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private IProductRepo _repo;
        static List<Product> product = new List<Product> { 
        new Product(){ProductId=1,ProductName="laptop",ProductCode="001",ProductPrice=50000},
        new Product(){ProductId=2,ProductName="mouse",ProductCode="002",ProductPrice=2000},
        new Product(){ProductId=3,ProductName="keyboard",ProductCode="003",ProductPrice=5000},
        new Product(){ProductId=4,ProductName="mobile",ProductCode="004",ProductPrice=10000},
        };
        public ProductController(ILogger<ProductController> logger, IProductRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult AddProduct(Product pro)
            
        {
            _logger.LogInformation("Product is getting added");
            product.Add(pro);
            return Ok();
        }
       
         [HttpGet]
         [Route("Read")]
        public List<Product> GetProduct()
        {
            _logger.LogInformation("retreiving all products");
            return product;
        }

        [HttpGet]
        [Route("find")]
        public IActionResult GetById(int id)
        {
            var res = product.FirstOrDefault(x => x.ProductId==id);
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
        public IActionResult UpdateProduct(Product pro)
        {
            _logger.LogInformation("updating product");
            var res = product.FirstOrDefault(x => x.ProductId == pro.ProductId);
         res.ProductCode= pro.ProductCode  ;
        res.ProductName= pro.ProductName ;
          res.ProductPrice= pro.ProductPrice ;
            return Ok();
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteProduct(int id)
        {
            _logger.LogInformation("deleting product");
            product.RemoveAll(p => p.ProductId == id);
           
            return Ok();
        }


        [HttpPost("Add")]
        public bool Add(Product product)
        {
            return _repo.Save(product);
        }
       
        [HttpGet]
        [Route("getallproducts")]
        public IEnumerable<Product> GetAllProducts()
        {
            return _repo.get();
        }

        [HttpGet]
        [Route("getbyid")]
        public Product GetAProductbyid(int id)
        {
            return _repo.getById(id);
        }

        [HttpDelete("DeleteProduct/{id}")]
        public bool Delete(int id)
        {
            return _repo.Delete(id);


        }


        [HttpPut("UpdateProduct")]
        public bool Update(Product product)
        {
            return _repo.Update(product);
        }
    }
}
