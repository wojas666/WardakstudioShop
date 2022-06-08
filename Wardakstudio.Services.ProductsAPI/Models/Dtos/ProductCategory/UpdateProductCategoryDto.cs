using Wardakstudio.Services.ProductsAPI.Models.Dtos.Common;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductCategory
{
    public class UpdateProductCategoryDto : BaseDto, IProductCategoryDto
    {
        public string CategoryName { get; set; }

        public string CategoryUrlSeo { get; set; }

        public int? ParentCategoryId { get; set; }
    }
}
