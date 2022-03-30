using CQRSLibrary.Data;
using CQRSLibrary.Models;
using CQRSLibrary.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSLibrary.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProducts, Product>
    {
        private readonly IProductService _service;
        public GetAllProductsHandler(IProductService service)
        {
            _service = service;
        }
        public Task<Product> Handle(Queries.GetAllProducts request, CancellationToken cancellationToken)
        {
            return (Task<Product>)_service.get();

        }
    }
}
