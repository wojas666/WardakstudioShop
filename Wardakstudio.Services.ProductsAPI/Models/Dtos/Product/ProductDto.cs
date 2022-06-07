using Wardakstudio.Services.ProductsAPI.Models.Dtos.Common;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductCategory;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductImage;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecification;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.Product
{
    public class ProductDto : BaseDto, IProductDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int AvailableQuantity { get; set; }

        public int ProductCategoryId { get; set; }

        public ProductCategoryDto ProductCategory { get; set; }

        public int ProducerId { get; set; }

        public ProducerDto Producer { get; set; }

        public virtual ICollection<ProductImageDto> ProductImages { get; set; }

        public virtual ICollection<ProductSpecificationDto> ProductSpecifications { get; set; }

        public bool IsPublished { get; set; }
    }
}
