namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductCategory
{
    public interface IProductCategoryDto
    {
        public string CategoryName { get; set; }

        public string CategoryUrlSeo { get; set; }

        public int? ParentCategoryId { get; set; }
    }
}
