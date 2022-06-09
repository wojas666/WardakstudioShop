using System.ComponentModel.DataAnnotations;
using Wardakstudio.Services.ProductsAPI.Models.Common;

namespace Wardakstudio.Services.ProductsAPI.Models
{
    public class ProductSpecification : BaseDomainEntity
    { 
        public Product Product { get; set; }

        public ProductSpecificationCategory ProductSpecificationCategory { get; set; }


        public ProductSpecificationDetail ProductSpecificationDetails { get; set; }

    }
}
