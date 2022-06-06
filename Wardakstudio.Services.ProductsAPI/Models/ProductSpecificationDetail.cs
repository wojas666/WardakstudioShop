using System.ComponentModel.DataAnnotations;
using Wardakstudio.Services.ProductsAPI.Models.Common;

namespace Wardakstudio.Services.ProductsAPI.Models
{
    public class ProductSpecificationDetail : BaseDomainEntity
    {
        [Required]
        public ProductSpecificationCategory ProductSpecificationCategory { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
