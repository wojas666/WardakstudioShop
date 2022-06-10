using System.ComponentModel.DataAnnotations;
using Wardakstudio.Services.ProductsAPI.Models.Common;

namespace Wardakstudio.Services.ProductsAPI.Models
{
    public class ProductImage : BaseDomainEntity
    {
        [Required]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }

        public int ProductId { get; set; }

        [Required]
        public virtual Product Product { get; set; }

        public bool IsBase { get; set; }

        public bool IsPublish { get; set; }
    }
}
