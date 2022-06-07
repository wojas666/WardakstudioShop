using Wardakstudio.Services.ProductsAPI.Models.Dtos.Common;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductImage
{
    public class ProductImageDto : BaseDto
    {
        public string ImageUrl { get; set; }

        public int ProductId { get; set; }

        public ProductDto Product { get; set; }

        public bool IsBase { get; set; }

        public bool IsPublished { get; set; }
    }
}
