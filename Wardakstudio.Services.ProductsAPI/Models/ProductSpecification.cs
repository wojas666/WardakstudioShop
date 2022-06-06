using System.ComponentModel.DataAnnotations;
using Wardakstudio.Services.ProductsAPI.Models.Common;

namespace Wardakstudio.Services.ProductsAPI.Models
{
    public class ProductSpecification : BaseDomainEntity
    { 
        [Required]
        public Product Product { get; set; }

        [Required]
        public ProductSpecificationCategory ProductSpecificationCategory { get; set; }

        [Required]
        public ProductSpecificationDetail ProductSpecificationDetails { get; set; }

    }
}
