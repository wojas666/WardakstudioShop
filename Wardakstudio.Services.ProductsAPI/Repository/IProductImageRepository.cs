using Wardakstudio.Services.ProductsAPI.Models;


namespace Wardakstudio.Services.ProductsAPI.Repository
{
    public interface IProductImageRepository : IGenericRepository<ProductImage>
    {
        Task<List<ProductImage>> GetProductImagesListForProduct(int productId);

        Task<ProductImage> GetBaseProductImageForProduct(int productId);
    }
}
