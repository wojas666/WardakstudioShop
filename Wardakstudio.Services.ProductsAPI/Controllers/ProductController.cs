using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wardakstudio.Services.ProductsAPI.Features.Products.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Features.Products.Requests.Queries;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product;
using Wardakstudio.Services.ProductsAPI.Responses;

namespace Wardakstudio.Services.ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> Get()
        {
            var products = await _mediator.Send(new GetProductsListRequest());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var product = await _mediator.Send(new GetProductDetailsRequest() { Id = id });
            return Ok(product);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<ProductDto>>> Search([FromBody]SearchProductDto search)
        {
            var products = await _mediator.Send(new GetSearchProductsListRequest() { SearchProduct = search });
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Create([FromBody]CreateProductDto product)
        {
            var command = new CreateProductCommand() { ProductDto = product };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand() { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody]UpdateProductDto product)
        {
            var command = new UpdateProductCommand() { ProductId = id, ProductToUpdate = product };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("ChangePublishedStatus")]
        public async Task<ActionResult> ChangePublishedStatus(int id, ChangeProductPublishedStatusDto product)
        {
            var command = new UpdateProductCommand() { ProductId = id, ChangeProductPublishedStatusDto = product };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
