using Microsoft.EntityFrameworkCore;
using Wardakstudio.Services.ProductsAPI.DbContexts;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Repository
{
    public class ProductImageRepository : GenericRepository<ProductImage>, IProductImageRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductImageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ChangeProductImagePublishedStatus(ProductImage product, bool? isPublished)
        {
            product.IsPublish = isPublished == null ? false : (bool)isPublished;

            _dbContext.Entry(product).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<ProductImage?> GetBaseProductImageForProduct(int productId)
        {
            return await _dbContext.Set<ProductImage>()
                .FirstOrDefaultAsync(x => x.IsBase == true);
        }

        public async Task<List<ProductImage>> GetProductImagesListForProduct(int productId)
        {
            return await _dbContext.Set<ProductImage>()
                .Where(x => x.Product.Id == productId).ToListAsync();
        }
    }
}
