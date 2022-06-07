using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductImage;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductImages.Requests.Commands
{
    public class UpdateProductImageCommand : IRequest
    {
        public int ProductImageId { get; set; }

        public ProductImageDto ImageToUpdate { get; set; }

        public ChangeProductImagePublishedStatusDto ChangeProductPublishedStatusDto { get; set; }
    }
}
