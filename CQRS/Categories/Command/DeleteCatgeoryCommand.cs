using MediatR;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Categories.Command
{
    public class DeleteCommand: IRequest<bool>
    {
        public int CategoryId { get; set; }

        public class DeleteCommandHandler : IRequestHandler<DeleteCommand, bool>
        {
            private readonly QueryFactory _db;
            public DeleteCommandHandler(QueryFactory db)
            {
                _db = db;
            }
            public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
                var x = _db.Query("Category").Where("CategoryId", "=", request.CategoryId.ToString()).Delete();
                return true;
            }
        }
    }
}
