using CQRS.Categories;
using CQRS.Categories.Command;
using CQRS.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Category : ControllerBase
    {

        private IMediator _mediator;

        public Category(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddCommand(AddCommand insert)
        {
            return Ok(await _mediator.Send(insert));
        }

         [HttpGet("getall")]
         public async Task<IActionResult> GetAll()
         {
             return Ok(await _mediator.Send(new GetAllCategories()));
         }

        [HttpGet]
         public async Task<IActionResult> Get(int id)
         {
             return Ok(await _mediator.Send(new GetCategorybyId { CategoryId = id }));
         }

        [HttpPut]
        public async Task<bool> Update(UpdateCategoryCommand update)
        {
            return await _mediator.Send(update);
        }

        [HttpDelete("Delete1")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteCommand { CategoryId = id }));
        }
    }
}
