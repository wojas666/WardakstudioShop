using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductImage;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductImages.Requests.Queries
{
    public class GetProductImageDetailsRequest : IRequest<ProductImageDto>
    {
        public int Id { get; set; }
    }
}
