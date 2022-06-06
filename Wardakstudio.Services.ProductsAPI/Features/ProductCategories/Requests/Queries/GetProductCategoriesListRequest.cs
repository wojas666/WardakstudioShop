using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductCategory;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductCategories.Requests.Queries
{
    public class GetProductCategoriesListRequest : IRequest<List<ProductCategoryDto>>
    {
    }
}
