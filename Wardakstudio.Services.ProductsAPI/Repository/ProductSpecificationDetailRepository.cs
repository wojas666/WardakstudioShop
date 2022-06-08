using Microsoft.EntityFrameworkCore;
using Wardakstudio.Services.ProductsAPI.DbContexts;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Repository
{
    public class ProductSpecificationDetailRepository : GenericRepository<ProductSpecificationDetail>,
        IProductSpecificationDetailRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductSpecificationDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProductSpecificationDetail>> GetProductSpecyficationsListForSpecificationCategory(int specificationCollectionId)
        {
            return await _dbContext.Set<ProductSpecificationDetail>()
                .Where(x => x.ProductSpecificationCategory.Id == specificationCollectionId)
                .ToListAsync();
        }
    }
}
