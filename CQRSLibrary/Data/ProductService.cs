using CQRSLibrary.Models;
using Microsoft.Extensions.Configuration;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSLibrary.Data
{
    public class ProductService : IProductService
    {
 IConfiguration _iconfiguration;

        private readonly QueryFactory _qf;

        public ProductService(IConfiguration iconfiguration)
        {
            var compiler = new SqlServerCompiler();

            var connection = new SqlConnection(iconfiguration.GetConnectionString("connection2").ToString());
            var db = new QueryFactory(connection, compiler);
            _qf = db;
            _iconfiguration = iconfiguration;
        }
       

        public bool Delete(int id)
        {
            var query = _qf.Query("Product").Where("ProductId", "=", id).Delete();
            return true;
        }

        public IEnumerable<Product> get()
        {
            var result = _qf.Query("Product")
                  .Select("Product.ProductId", "Product.ProductName", "Product.ProductPrice", "Product.ProductCode").Get<Product>();

            return result;

        }

        public Product getById(int id)
        {
            return _qf.Query("Product")
               .Select("Product.ProductId", "Product.ProductName", "Product.ProductPrice", "Product.ProductCode")
              .Where("Product.ProductId", "=", id).First<Product>();
        }

        public bool Save(Product pro)
        {
            var query = _qf.Query("Product").Insert(new
            {
                //  ProductId = pro.ProductId,
                ProductName = pro.ProductName,
                ProductPrice = pro.ProductPrice,
                ProductCode = pro.ProductCode
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
                ProductCode = pro.ProductCode
            });
            return true;
        }
    }
}
