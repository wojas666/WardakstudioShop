using Microsoft.EntityFrameworkCore;
using Wardakstudio.Services.ProductsAPI.DbContexts;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override Task<Product> Add(Product entity)
        {

            return base.Add(entity);
        }

        public async Task ChangeProductPublishedStatus(Product product, bool? isPublished)
        {
            product.IsPublished = isPublished == null ? false : (bool)isPublished;
            _dbContext.Entry(product).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetSearchProductsList(SearchProductDto searchProductDto)
        {
            IQueryable<Product> searchedProducts = _dbContext.Set<Product>();

            if (!String.IsNullOrEmpty(searchProductDto.Name))
                searchedProducts = searchedProducts.Where(x => x.Name.Contains(searchProductDto.Name));

            if (searchProductDto.IsAvailable)
                searchedProducts = searchedProducts.Where(x => x.AvailableQuantity > 0);

            if (searchProductDto.ProductCategoryIds != null)
                searchedProducts = searchedProducts.Where(x => searchProductDto.ProductCategoryIds
                .Any(y => y == x.ProductCategory.Id));

            if (searchProductDto.MinPrice != null)
                searchedProducts = searchedProducts.Where(x => x.Price >= searchProductDto.MinPrice);

            if (searchProductDto.MaxPrice != null)
                searchedProducts = searchedProducts.Where(x => x.Price <= searchProductDto.MaxPrice);

            if(searchProductDto.ProducerIds != null)
                searchedProducts = searchedProducts.Where(x => searchProductDto.ProducerIds
                .Any(y => y == x.Producer.Id));

            switch (searchProductDto.SortType)
            {
                case SortType.LowPrice:
                    searchedProducts = searchedProducts.OrderBy(x => x.Price);
                    break;
                case SortType.HighPrice:
                    searchedProducts = searchedProducts.OrderByDescending(x => x.Price);
                    break;
                case SortType.NewProduct:
                    searchedProducts = searchedProducts.OrderByDescending(x => x.DateCreated);
                    break;
            }

            return await searchedProducts.ToListAsync();
        }
    }
}
