using System.ComponentModel.DataAnnotations;
using Wardakstudio.Services.ProductsAPI.Models.Common;

namespace Wardakstudio.Services.ProductsAPI.Models
{
    public class ProductSpecificationCategory : BaseDomainEntity
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ProductSpecificationDetail> ProductSpecificationDetails { get; set; }
    }
}
