using Wardakstudio.Services.ProductsAPI.Models;


namespace Wardakstudio.Services.ProductsAPI.Repository.Contracts
{
    public interface IProductSpecificationRepository : IGenericRepository<ProductSpecification>
    {
        Task<List<ProductSpecification>> GetProductSpecificationsList(int productId);

    }
}
