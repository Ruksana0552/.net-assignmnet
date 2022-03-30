using MediatR;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Categories
{
    public class UpdateCategoryCommand: IRequest<bool>
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public class UpdateCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
        {
            private readonly QueryFactory _db;
            public UpdateCommandHandler(QueryFactory db)
            {
                _db = db;
            }
            public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                var query = _db.Query("Category").Where("CategoryId", "=", request.CategoryId).Update(new
                {
                   //CategoryId = request.CategoryId,
                    CategoryName = request.CategoryName
                });
                return true;
            }
        }
    }
}
