using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecificationCategory;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductSpecificationCategories.Requests.Commands
{
    public class CreateProductSpecificationCategoryCommand : IRequest<int>
    {
        public CreateProductSpecificationCategoryDto ProductSpecificationCategoryDto { get; set; }
    }
}
