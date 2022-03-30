using CQRSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSLibrary.Data
{
   public interface IProductService
    {
        public IEnumerable<Product> get();

        public bool Save(Product pro);
        public bool Update(Product pro);
        public Product getById(int id);

        public bool Delete(int id);
    }
}
