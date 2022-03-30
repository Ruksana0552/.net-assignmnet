using Assignment1.Models;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.services
{
  public  interface IProductRepo
    {
        public IEnumerable<Product> get();

        public bool Save(Product pro );
        public bool Update(Product pro);
        public Product getById(int id);

        public bool Delete(int id);
        

    }
}
