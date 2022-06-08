using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecificationDetail;

namespace Wardakstudio.Services.ProductsAPI.Repository.Contracts
{
    public interface IProductSpecificationDetailRepository : IGenericRepository<ProductSpecificationDetail>
    {
        Task<List<ProductSpecificationDetail>> GetProductSpecyficationsListForSpecificationCategory(int specificationCollectionId);
    }
}
