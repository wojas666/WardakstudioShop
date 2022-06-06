using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductImage;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductImages.Requests.Commands
{
    public class CreateProductImageRequest : IRequest<int>
    {
        public CreateProductImageDto ProductImageDto { get; set; }
    }
}
