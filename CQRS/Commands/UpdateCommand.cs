using MediatR;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Commands
{
    public class UpdateCommand:IRequest<bool>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public decimal ProductPrice { get; set; }
        public int CategoryId { get; set; }

        public class UpdateCommandHandler : IRequestHandler<UpdateCommand,bool>
        {
            private readonly QueryFactory _db;
            public UpdateCommandHandler(QueryFactory db)
            {
                _db = db;
            }

            public async Task<bool> Handle(UpdateCommand request, CancellationToken cancellationToken)
            {
                var query = _db.Query("Product").Where("ProductId", "=", request.ProductId).Update(new
                {
                   // ProductId = request.ProductId,
                    ProductName = request.ProductName,
                    ProductPrice = request.ProductPrice,
                    ProductCode=request.ProductCode,
                   CategoryId = request.CategoryId,
                  //name=request.
                });
                return true;
            }
        }
    }
}
