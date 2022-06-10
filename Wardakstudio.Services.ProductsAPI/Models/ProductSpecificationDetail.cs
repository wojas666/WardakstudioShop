using System.ComponentModel.DataAnnotations;
using Wardakstudio.Services.ProductsAPI.Models.Common;

namespace Wardakstudio.Services.ProductsAPI.Models
{
    public class ProductSpecificationDetail : BaseDomainEntity
    {
        public int ProductSpecificationCategoryId { get; set; }

        [Required]
        public virtual ProductSpecificationCategory ProductSpecificationCategory { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
