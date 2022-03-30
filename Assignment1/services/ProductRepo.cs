using Assignment1.Models;

using Microsoft.Extensions.Configuration;
using SqlKata.Compilers;
using SqlKata.Execution;
using SqlKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Assignment1.services
{
    public class ProductRepo : IProductRepo
    {
        IConfiguration _iconfiguration;

          private readonly QueryFactory _qf;
      
        public ProductRepo( IConfiguration iconfiguration)
        {
            var compiler = new SqlServerCompiler();
           
            var connection = new SqlConnection(iconfiguration.GetConnectionString("connection2").ToString());
            var db = new QueryFactory(connection, compiler);
            _qf = db;
        _iconfiguration = iconfiguration;
        }
       public QueryFactory config()
        {
            var compiler = new SqlServerCompiler();

            var connection = new SqlConnection(_iconfiguration.GetConnectionString("connection2").ToString());
            var db = new QueryFactory(connection, compiler);
            return db;
        }
        public IEnumerable<Product> get()
        {
            var result = _qf.Query("Product")
                 .Select("Product.ProductId", "Product.ProductName", "Product.ProductPrice", "Product.ProductCode").Get<Product>();
            //var result = new Query("Product").Join("Category", "Product1.ProductId", "Category1.CategoryId").
            //    Select("Product1.ProductId", "Product1.ProductName", "Product1.ProductPrice", "Product1.ProductCode","Category1.CategoryName");
            return (IEnumerable<Product>)result;

        }

        public Product getById(int id)
        {

            return _qf.Query("Product")
                .Select("Product.ProductId", "Product.ProductName", "Product.ProductPrice", "Product.ProductCode")
               .Where("Product.ProductId", "=", id).First<Product>();
            
        }

        public bool Delete(int id)
        {
            var query = _qf.Query("Product").Where("ProductId", "=", id).Delete();
            return true;
        }

        public bool Save(Product pro)
        {
          
            var query =_qf.Query("Product").Insert(new
            {
              //  ProductId = pro.ProductId,
                ProductName = pro.ProductName,
                ProductPrice = pro.ProductPrice,
                ProductCode=pro.ProductCode
            });
            return true;
        }

        public bool Update(Product pro)
        {
            var query = _qf.Query("Product").Where("ProductId", "=", pro.ProductId).Update(new
            {
               // ProductId = pro.ProductId,
                ProductName = pro.ProductName,
                ProductPrice = pro.ProductPrice,
                ProductCode=pro.ProductCode
            });
            return true;
        }
    }
}
