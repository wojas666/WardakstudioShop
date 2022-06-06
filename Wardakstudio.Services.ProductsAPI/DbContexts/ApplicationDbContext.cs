using Microsoft.EntityFrameworkCore;
using Wardakstudio.Services.ProductsAPI.Models;

namespace Wardakstudio.Services.ProductsAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        DbSet<Product> Products { get; set; }

        DbSet<Producer> Producers { get; set; }

        DbSet<ProductCategory> ProductCategories { get; set; }

        DbSet<ProductImage> ProductImages { get; set; }

        DbSet<ProductSpecification> ProductSpecifications { get; set; }

        DbSet<ProductSpecificationCategory> ProductSpecificationCategories { get; set; }

        DbSet<ProductSpecificationDetail> ProductSpecificationDetails { get; set; }
    }
}
