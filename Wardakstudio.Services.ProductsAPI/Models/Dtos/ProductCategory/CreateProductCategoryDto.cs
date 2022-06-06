namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductCategory
{
    public class CreateProductCategoryDto
    {
        public string CategoryName { get; set; }

        public string CategoryUrlSeo { get; set; }

        public ProductCategoryDto? ParentCategory { get; set; }
    }
}
