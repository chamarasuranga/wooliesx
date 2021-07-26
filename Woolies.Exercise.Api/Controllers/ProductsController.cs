using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Woolies.Exercise.Application.Features.Products;
using Woolies.Exercise.Application.Features.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Woolies.Exercise.Api.Controllers
{
    [Route("api/WooliesExercise/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetTrollyTotal")]
        public async Task<ActionResult<List<ProductDto>>> GetTrollyTotal([FromBody]GetTrollyTotalQuery query)
        {
            var sortedProducts = await _mediator.Send(query);
            return Ok(sortedProducts);
        }


        [HttpGet("getSortedProducts")]
        public async Task<ActionResult<List<ProductDto>>> GetSortedProducts([FromQuery]SortOptions? sortOption)
        {
            // note : when calling this u can use  either the  id or string of SortOption enum , ex 0 or 'low' both with work 

            var sortedProducts = await _mediator.Send(new GetSortedProductsQuery() { SortOption = sortOption });
            return Ok(sortedProducts);
        }

    }
}