using CQRSLibrary.Models;
using MediatR;
using Microsoft.Extensions.Configuration;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSLibrary.Queries
{
    public class GetProductQueryreq : IRequest<IEnumerable<Product>>
    {

    }
    public class GetAllProductQueryHandler : IRequestHandler<GetProductQueryreq, IEnumerable<Product>>
    {
        IConfiguration _iconfiguration;

        private readonly QueryFactory _qf;

        public GetAllProductQueryHandler(IConfiguration iconfiguration)
        {
            var compiler = new SqlServerCompiler();

            var connection = new SqlConnection(iconfiguration.GetConnectionString("connection2").ToString());
            var db = new QueryFactory(connection, compiler);
            _qf = db;
            _iconfiguration = iconfiguration;
        }

        public  Task<IEnumerable<Product>> Handle(GetProductQueryreq request, CancellationToken cancellationToken)
        {
            return
                (Task<IEnumerable<Product>>)_qf.Query("Product")
               .Select("Product.ProductId", "Product.ProductName", "Product.ProductPrice").Get<Product>();
        }
    }

}


