using MediatR;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Commands
{
    public class DeleteCommand:IRequest<bool>

    {
         public int ProductId { get; set; }

        public class DeleteCommandHandler : IRequestHandler<DeleteCommand, bool>
        {
            private readonly QueryFactory _db;
            public DeleteCommandHandler(QueryFactory db)
            {
                _db = db;
            }

            public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
                var x = _db.Query("Product").Where("ProductId", "=", request.ProductId.ToString()).Delete();
                return true;
            }
        }
    }
}
