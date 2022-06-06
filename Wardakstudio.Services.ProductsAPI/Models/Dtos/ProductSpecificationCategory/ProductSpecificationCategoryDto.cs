using Wardakstudio.Services.ProductsAPI.Models.Dtos.Common;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecificationDetail;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecificationCategory
{
    public class ProductSpecificationCategoryDto : BaseDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<ProductSpecificationDetailDto> ProductSpecificationDetails { get; set; }
    }
}
