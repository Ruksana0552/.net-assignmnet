using Assignment1.Models;
using Microsoft.Extensions.Configuration;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.services
{
  
    public class Categoryrepo : ICategory
    {
      

        private readonly QueryFactory _qf;

      public Categoryrepo(QueryFactory qf)
        {
            _qf = qf;
        }
        public bool Add(Category cat)
        {
            var query = _qf.Query("Category").Insert(new
            {
              //  CategoryId = cat.CategoryId,
                CategoryName = cat.CategoryName

            });
            return true;
        }

        public bool Delete(int id)
        {
            var x = _qf.Query("Category").Where("CategoryId", "=", id).Delete();
            return true;
        }

        public Category Get(int id)
        {
            var res= _qf.Query("Category")
               .Select("Category.CategoryId", "Category.CategoryName")
              .Where("Category.CategoryId", "=", id).First<Category>();

            return res;
        }

        public IEnumerable<Category> GetAll()
        {
            return _qf.Query("Category")
                  .Select("Category.CategoryId", "Category.CategoryName").Get<Category>();
        }

        public bool Update(Category cat)
        {
            var query = _qf.Query("Category").Where("CategoryId", "=", cat.CategoryId).Update(new
            {
               // CategoryId = cat.CategoryId,
                CategoryName =cat.CategoryName
            });
            return true;
        }
    }
}
