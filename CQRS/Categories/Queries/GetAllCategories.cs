using CQRS.Models;
using MediatR;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Categories.Queries
{
    public class GetAllCategories:IRequest<IEnumerable<Category>>
    {
        public class GetAllCategoriesHandler : IRequestHandler<GetAllCategories, IEnumerable<Category>>
        {
            private readonly QueryFactory _db;
            public GetAllCategoriesHandler(QueryFactory db)
            {
                _db = db;
            }
            public async Task<IEnumerable<Category>> Handle(GetAllCategories request, CancellationToken cancellationToken)
            {
                return (IEnumerable<Category>)_db.Query("Category")
                 .Select("Category.CategoryId", "Category.CategoryName").Get<Category>();
            }
        }
    }
}
