using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecificationDetail;

namespace Wardakstudio.Services.ProductsAPI.Repository
{
    public interface IProductSpecificationDetailRepository : IGenericRepository<ProductSpecificationDetail>
    {
        Task<List<ProductSpecificationDetailDto>> GetProductSpecyficationsListForSpecificationCategory(int specificationCollectionId);
    }
}
