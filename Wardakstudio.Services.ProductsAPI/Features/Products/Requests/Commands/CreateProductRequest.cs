using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product;

namespace Wardakstudio.Services.ProductsAPI.Features.Products.Requests.Commands
{
    public class CreateProductRequest : IRequest<int>
    {
        public CreateProductDto ProductDto { get; set; }
    }
}
