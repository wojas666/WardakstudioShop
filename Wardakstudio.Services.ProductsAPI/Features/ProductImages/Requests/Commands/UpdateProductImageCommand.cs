using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductImage;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductImages.Requests.Commands
{
    public class UpdateProductImageCommand : IRequest
    {
        public int ProductImageId { get; set; }

        public UpdateProductImageDto ImageToUpdate { get; set; }

        public ChangeProductImagePublishedStatusDto ChangeProductImagePublishedStatusDto { get; set; }

        public ChangeBaseProductImageDto ChangeBaseProductImageDto { get; set; }
    }
}
