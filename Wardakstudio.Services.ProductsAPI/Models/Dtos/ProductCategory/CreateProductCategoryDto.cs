namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductCategory
{
    public class CreateProductCategoryDto : IProductCategoryDto
    {
        public string CategoryName { get; set; }

        public string CategoryUrlSeo { get; set; }

        public int? ParentCategoryId { get; set; } = null;
    }
}
