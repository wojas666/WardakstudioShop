using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product;

namespace Wardakstudio.Services.ProductsAPI.Features.Products.Requests.Queries
{
    public class GetProductDetailsRequest : IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}
