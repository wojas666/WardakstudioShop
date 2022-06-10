using System.ComponentModel.DataAnnotations;
using Wardakstudio.Services.ProductsAPI.Models.Common;

namespace Wardakstudio.Services.ProductsAPI.Models
{
    public class ProductSpecification : BaseDomainEntity
    { 
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int ProductSpecificationCategoryId { get; set; }

        public virtual ProductSpecificationCategory ProductSpecificationCategory { get; set; }

        public int ProductSpecificationDetailId { get; set; }

        public virtual ProductSpecificationDetail ProductSpecificationDetails { get; set; }

    }
}
