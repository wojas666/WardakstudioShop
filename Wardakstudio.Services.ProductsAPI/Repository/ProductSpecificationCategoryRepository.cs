using Wardakstudio.Services.ProductsAPI.DbContexts;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Repository
{
    public class ProductSpecificationCategoryRepository : GenericRepository<ProductSpecificationCategory>, 
        IProductSpecificationCategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductSpecificationCategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
