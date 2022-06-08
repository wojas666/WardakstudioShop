using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductCategory;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductCategories.Requests.Commands
{
    public class UpdateProductCategoryCommand : IRequest
    {
        public UpdateProductCategoryDto ProductCategoryUpdate { get; set; }
    }
}
