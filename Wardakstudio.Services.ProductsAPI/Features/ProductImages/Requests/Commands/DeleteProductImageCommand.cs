using MediatR;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductImages.Requests.Commands
{
    public class DeleteProductImageCommand : IRequest
    {
        public int Id { get; set; }
    }
}
