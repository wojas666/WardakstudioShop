using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductImage;
using Wardakstudio.Services.ProductsAPI.Responses;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductImages.Requests.Commands
{
    public class CreateProductImageCommand : IRequest<BaseCommandResponse>
    {
        public CreateProductImageDto ProductImageDto { get; set; }
    }
}
