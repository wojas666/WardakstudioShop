using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product;

namespace Wardakstudio.Services.ProductsAPI.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetSearchProductsList(SearchProductDto searchProductDto);
    }
}
