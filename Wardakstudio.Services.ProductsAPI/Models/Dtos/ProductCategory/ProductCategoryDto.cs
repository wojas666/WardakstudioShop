using System.ComponentModel.DataAnnotations.Schema;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Common;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductCategory
{
    public class ProductCategoryDto : BaseDto
    {
        public string CategoryName { get; set; }

        public string CategoryUrlSeo { get; set; }

        [ForeignKey("ParentCategory")]
        public int? ParentCategoryId { get; set; }

        public virtual ProductCategoryDto ParentCategory { get; set; }

        public virtual ICollection<ProductCategoryDto> Children { get; set; }

        public virtual ICollection<ProductDto> Products { get; set; }
    }
}
