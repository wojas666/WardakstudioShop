using Wardakstudio.Services.ProductsAPI.DbContexts;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Repository
{
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductCategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
