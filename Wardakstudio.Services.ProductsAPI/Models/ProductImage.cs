using System.ComponentModel.DataAnnotations;
using Wardakstudio.Services.ProductsAPI.Models.Common;

namespace Wardakstudio.Services.ProductsAPI.Models
{
    public class ProductImage : BaseDomainEntity
    {
        [Required]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }

        [Required]
        public Product Product { get; set; }

        public bool IsBase { get; set; }

        public bool IsPublish { get; set; }
    }
}
