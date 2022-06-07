using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product;

namespace Wardakstudio.Services.ProductsAPI.Features.Products.Requests.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public ProductDto Product { get; set; }
    }
}
