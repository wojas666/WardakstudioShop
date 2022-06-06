using Wardakstudio.Services.ProductsAPI.Models.Dtos.Common;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecificationCategory;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecificationDetail
{
    public class ProductSpecificationDetailDto : BaseDto
    {
        public ProductSpecificationCategoryDto ProductSpecificationCategory { get; set; }

        public string Name { get; set; }
    }
}
