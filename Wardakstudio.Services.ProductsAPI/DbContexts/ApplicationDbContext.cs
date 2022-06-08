using Microsoft.EntityFrameworkCore;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Models.Common;

namespace Wardakstudio.Services.ProductsAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastDateModified = DateTime.Now;

                if(entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
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
