using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductCategory;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductCategories.Requests.Commands
{
    public class CreateProductCategoryCommand : IRequest<int>
    {
        public CreateProductCategoryDto ProductCategoryDto { get; set; }
    }
}
