using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product;

namespace Wardakstudio.Services.ProductsAPI.Features.Products.Requests.Commands
{
    public class UpdateProductCommand : IRequest
    {
        public int ProductId { get; set; }

        public ProductDto ProductToUpdate { get; set; }

        public ChangeProductPublishedStatusDto ChangeProductPublishedStatusDto { get; set; }
    }
}
