using CQRS.Commands;
using CQRS.Queries;
using CQRSLibrary.Handlers;
using CQRSLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CQRSLibrary.Queries.GetProductQueryreq;

namespace CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class Product : ControllerBase
    {
        private readonly ILogger<Product> _logger;
        private  IMediator _mediator;
     
        public Product(IMediator mediator, ILogger<Product> logger)
        {
            this._mediator = mediator;
            _logger = logger;
        }
       [HttpPost]
       public async Task<IActionResult> AddCommand(InsertCommand insert)
        {
            return Ok(await _mediator.Send(insert));
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllProducts()
        {
            _logger.LogInformation("retrieving products");
            return Ok(await _mediator.Send(new GetProductsQuery()));
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct(int id)
        {
            _logger.LogInformation("retrieving products");
            return  Ok( await _mediator.Send(new GetProductbyIdQuery { ProductId = id }));
        }

        [HttpPut]
        public async Task<bool> UpdateProduct(UpdateCommand update)
        {
            return await _mediator.Send(update);
        }

        [HttpDelete("Delete")]
    
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return Ok(await _mediator.Send(new DeleteCommand{ProductId=id}));
        }


    }

}