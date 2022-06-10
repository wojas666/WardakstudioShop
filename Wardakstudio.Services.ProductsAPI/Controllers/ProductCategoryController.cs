using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wardakstudio.Services.ProductsAPI.Features.ProductCategories.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Features.ProductCategories.Requests.Queries;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductCategory;
using Wardakstudio.Services.ProductsAPI.Responses;

namespace Wardakstudio.Services.ProductsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductCategoryDto>>> Get()
        {
            var productCategories = await _mediator.Send(new GetProductCategoriesListRequest());
            return Ok(productCategories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategoryDto>> Get(int id)
        {
            var productCategory = await _mediator.Send(new GetProductCategoryDetailsRequest() { Id = id });
            return Ok(productCategory);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Create(CreateProductCategoryDto productCategory)
        {
            var command = new CreateProductCategoryCommand() { ProductCategoryDto = productCategory };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateProductCategoryDto productCategory)
        {
            var command = new UpdateProductCategoryCommand() { ProductCategoryUpdate = productCategory };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProductCategoryCommand() { ProductCategoryId = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
