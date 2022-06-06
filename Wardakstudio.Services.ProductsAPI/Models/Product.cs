using System.ComponentModel.DataAnnotations;
using Wardakstudio.Services.ProductsAPI.Models.Common;

namespace Wardakstudio.Services.ProductsAPI.Models
{
    public class Product : BaseDomainEntity
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int AvailableQuantity { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public Producer Producer { get; set; }

        public virtual ICollection<ProductImage> ProductImages { get; set; }

        public virtual ICollection<ProductSpecification> ProductSpecifications { get; set; }

        public bool IsPublished { get; set; }
    }
}
