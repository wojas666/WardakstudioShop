using Microsoft.AspNetCore.Mvc;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductImage;
using Wardakstudio.Services.ProductsAPI.Features.ProductImages.Requests.Queries;
using Wardakstudio.Services.ProductsAPI.Features.ProductImages.Requests.Commands;

namespace Wardakstudio.Services.ProductsAPI.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductImageDto>>> Get()
        {
            var allProductImages = await _mediator.Send(new GetAllProductsImagesListRequest());

            return Ok(allProductImages);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductImageDto>> Get(int id)
        {
            var productImage = await _mediator.Send(new GetProductImageDetailsRequest() { Id = id });

            return Ok(productImage);
        }

        [HttpGet("GetForProduct/{id}")]
        public async Task<ActionResult<List<ProductImageDto>>> GetForProduct(int productId)
        {
            var productImages = await _mediator.Send(new GetProductImagesListRequest() { ProductId = productId });

            return Ok(productImages);
        }

        [HttpGet("GetBaseImageForProduct/{productId}")]
        public async Task<ActionResult<ProductImageDto?>> GetBaseImageForProduct(int productId)
        {
            var productBaseImage = await _mediator.Send(new GetBaseProductImageRequest() { ProductId = productId });

            return Ok(productBaseImage);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateProductImageDto productImage)
        {
            var command = new CreateProductImageCommand() { ProductImageDto = productImage };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateProductImageDto imageToUpdate)
        {
            var command = new UpdateProductImageCommand() { ProductImageId = imageToUpdate.Id, ImageToUpdate = imageToUpdate };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("ChangePublishedStatus/{id}")]
        public async Task<ActionResult> ChangePublishedStatus(int id, [FromBody]ChangeProductImagePublishedStatusDto publishedStatus)
        {
            var command = new UpdateProductImageCommand() { ProductImageId = id, ChangeProductImagePublishedStatusDto = publishedStatus };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("ChangeBaseImage/{productImageId}")]
        public async Task<ActionResult> ChangeBaseProductImage(int productImageId, [FromBody]ChangeBaseProductImageDto baseProductImage)
        {
            var command = new UpdateProductImageCommand() { ProductImageId = productImageId, ChangeBaseProductImageDto = baseProductImage };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProductImageCommand() { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
