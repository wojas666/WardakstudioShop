using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductCategory;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductCategories.Requests.Commands
{
    public class CreateProductCategoryRequest : IRequest<int>
    {
        public CreateProductCategoryDto ProductCategoryDto { get; set; }
    }
}
