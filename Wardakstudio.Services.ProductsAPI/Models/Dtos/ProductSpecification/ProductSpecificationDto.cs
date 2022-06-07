using Wardakstudio.Services.ProductsAPI.Models.Dtos.Common;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecificationCategory;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecificationDetail;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecification
{
    public class ProductSpecificationDto : BaseDto
    {
        public ProductDto Product { get; set; }

        public int ProductSpecificationCategoryId { get; set; }

        public ProductSpecificationCategoryDto ProductSpecificationCategory { get; set; }

        public int ProductSpecificationDetailsId { get; set; }

        public ProductSpecificationDetailDto ProductSpecificationDetails { get; set; }
    }
}
