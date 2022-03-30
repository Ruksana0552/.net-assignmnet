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
    public class GetProductsQuery : IRequest<IEnumerable<Product>>

    { //public string CategoryName { get; set; }
        public class GetProductQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
        {
            private readonly QueryFactory _db;
            public GetProductQueryHandler(QueryFactory db)
            {
                _db = db;
            }
            public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            {
                //IEnumerable<object> res = _db.Query("Product").Join("Category", "Product.CategoryId", "Category.CategoryId")
                //                                    .Select("Product.ProductId ", "Product.ProductName", "Product.ProductPrice", "Product.ProductCode", "Product.CategoryId", "Category.CategoryName as categoryname").Get<object>();



                IEnumerable<Product> res = (IEnumerable<Product>)_db.Query("Product").Join("Category", "Product.CategoryId", "Category.CategoryId")
                                                    .Select("Product.ProductId", "Product.ProductName", "Product.ProductPrice", "Product.ProductCode", "Product.CategoryId", "Category.CategoryName as CategoryName").Get<Product>();


                return res;

                //    return (IEnumerable<Product>)_db.Query("Product")
                //    .Select("Product.ProductId", "Product.ProductName", "Product.ProductPrice", "Product.ProductCode", "Product.CategoryId").Get<Product>();
                //}
            }
        }
    }
}
