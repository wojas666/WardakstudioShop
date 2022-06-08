using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductCategory;
using Wardakstudio.Services.ProductsAPI.Responses;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductCategories.Requests.Commands
{
    public class CreateProductCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateProductCategoryDto ProductCategoryDto { get; set; }
    }
}
