using MediatR;

namespace Wardakstudio.Services.ProductsAPI.Features.Products.Requests.Commands
{
    public class DeleteProductByIdCommand : IRequest
    {
        public int Id { get; set; }
    }
}
