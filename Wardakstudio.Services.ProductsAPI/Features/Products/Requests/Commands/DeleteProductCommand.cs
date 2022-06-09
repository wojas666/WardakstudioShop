using MediatR;

namespace Wardakstudio.Services.ProductsAPI.Features.Products.Requests.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}
