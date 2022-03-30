
using CQRS.Models;
using MediatR;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Queries
{
    public class GetProductbyIdQuery:IRequest<Product>
    {
        public int ProductId { get; set; }
        public class GetProductbyIdHandler : IRequestHandler<GetProductbyIdQuery, Product>
        {
            private readonly QueryFactory _db;
            public GetProductbyIdHandler(QueryFactory db)
            {
                _db = db;
            }
            public async Task<Product> Handle(GetProductbyIdQuery request, CancellationToken cancellationToken)
            {
                var x = request.ProductId;

                return _db.Query("Product")
                    .Select("Product.ProductId", "Product.ProductName", "Product.ProductPrice")
                   .Where("Product.ProductId", "=", x).First<Product>();
            }
        }

    }
}
