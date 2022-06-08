using Microsoft.EntityFrameworkCore;
using Wardakstudio.Services.ProductsAPI.DbContexts;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Repository
{
    public class ProductSpecificationRepository : GenericRepository<ProductSpecification>, 
        IProductSpecificationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductSpecificationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProductSpecification>> GetProductSpecificationsList(int productId)
        {
            return await _dbContext.Set<ProductSpecification>()
                .Where(x => x.Product.Id == productId)
                .ToListAsync();
        }
    }
}
