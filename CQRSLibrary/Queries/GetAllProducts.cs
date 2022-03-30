using CQRSLibrary.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSLibrary.Queries
{
  public  class GetAllProducts: IRequest<Product>
    {
        
    }
}
