using MediatR;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Commands
{
    public class InsertCommand:IRequest<bool>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public decimal ProductPrice { get; set; }
     
        public int CategoryId { get; set; }

        public class InsertCommandHandler : IRequestHandler<InsertCommand, bool>
        {
            private QueryFactory _db;
            public InsertCommandHandler(QueryFactory db)
            {
                _db = db;
            }
            public async Task<bool> Handle(InsertCommand request, CancellationToken cancellationToken)
            {
                var x = _db.Query("Product").Insert(new
                {
                   //ProductId = request.ProductId,
                    ProductName = request.ProductName,
                    ProductPrice = request.ProductPrice,
                    ProductCode=request.ProductCode,
                    Categoryid=request.CategoryId
                });

                return true;
            
            }
        }
    }
}
