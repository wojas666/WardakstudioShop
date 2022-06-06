using System.ComponentModel.DataAnnotations;
using Wardakstudio.Services.ProductsAPI.Models.Common;

namespace Wardakstudio.Services.ProductsAPI.Models
{
    public class ProductCategory : BaseDomainEntity
    {
        [Required]
        public string CategoryName { get; set; }

        [Required]
        public string CategoryUrlSeo { get; set; }

        public ProductCategory? ParentCategory { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
