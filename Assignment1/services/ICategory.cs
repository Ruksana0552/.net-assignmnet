using Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.services
{
  public  interface ICategory
    {
        IEnumerable<Category> GetAll();
        Category Get(int id);
        bool Add(Category cat);
        bool Delete(int id);
        bool Update(Category cat);
    }
}
