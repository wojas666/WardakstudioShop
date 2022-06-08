
using Microsoft.EntityFrameworkCore;
using Wardakstudio.Services.ProductsAPI.DbContexts;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Repository
{
    public class ProductRatingRepository : GenericRepository<ProductRating>, IProductRatingRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRatingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ChangeApprovalStatus(ProductRating productRating, bool? isApproved)
        {
            productRating.IsApproved = isApproved == null ? false : (bool)isApproved;
            _dbContext.Entry(productRating).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ProductRating>> GetProductRatings(int productId)
        {
            return await _dbContext.Set<ProductRating>()
                .Where(x => x.Product.Id == productId)
                .ToListAsync();
        }
    }
}
