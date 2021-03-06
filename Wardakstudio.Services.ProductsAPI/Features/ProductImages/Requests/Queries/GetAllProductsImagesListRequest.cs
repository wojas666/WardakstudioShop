using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductImage;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductImages.Requests.Queries
{
    public class GetAllProductsImagesListRequest : IRequest<List<ProductImageDto>>
    {
    }
}
