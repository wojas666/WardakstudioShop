using Microsoft.EntityFrameworkCore;
using Wardakstudio.Services.ProductsAPI.DbContexts;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Repository
{
    public class ProducerRepository : GenericRepository<Producer>, IProducerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProducerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
