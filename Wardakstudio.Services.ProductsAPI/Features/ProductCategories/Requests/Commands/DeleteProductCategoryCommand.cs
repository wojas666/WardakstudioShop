using MediatR;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductCategories.Requests.Commands
{
    public class DeleteProductCategoryCommand : IRequest
    {
        public int ProductCategoryId { get; set; }
    }
}
