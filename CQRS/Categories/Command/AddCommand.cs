using MediatR;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Categories.Command
{
    public class AddCommand: IRequest<bool>
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public class AddCommandHandler : IRequestHandler<AddCommand, bool>
        {
            private readonly QueryFactory _db;
            public AddCommandHandler(QueryFactory db)
            {
                _db = db;
            }
            public async Task<bool> Handle(AddCommand request, CancellationToken cancellationToken)
            {
                var query = _db.Query("Category").Insert(new
                {
                  // CategoryId = request.CategoryId,
                    CategoryName = request.CategoryName
                });
                return true;
            }
        }
    }
}
