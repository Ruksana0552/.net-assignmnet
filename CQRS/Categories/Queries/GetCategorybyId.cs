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
    public class GetCategorybyId : IRequest<Category>
    {
        public int CategoryId { get; set; }

        public class GetCategorybyIdHandler : IRequestHandler<GetCategorybyId, Category>
        {
            private readonly QueryFactory _db;
            public GetCategorybyIdHandler(QueryFactory db)
            {
                _db = db;
            }
            public async Task<Category> Handle(GetCategorybyId request, CancellationToken cancellationToken)
            {
                var res= request.CategoryId;

                return _db.Query("Category")
                    .Select("Category.CategoryId", "Category.CategoryName")
                   .Where("Category.CategoryId", "=", res).First<Category>();

            }
        }

    }
}
