using Wardakstudio.Services.ProductsAPI.Models;


namespace Wardakstudio.Services.ProductsAPI.Repository.Contracts
{
    public interface IProductImageRepository : IGenericRepository<ProductImage>
    {
        Task<List<ProductImage>> GetProductImagesListForProduct(int productId);

        Task<ProductImage?> GetBaseProductImageForProduct(int productId);

        Task ChangeProductImagePublishedStatus(ProductImage product, bool? isPublished);

        Task ChangeBaseProductImage(ProductImage productImage, bool? isBase);
    }
}
