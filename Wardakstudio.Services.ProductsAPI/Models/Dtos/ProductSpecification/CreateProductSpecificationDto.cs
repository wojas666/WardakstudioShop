namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecification
{
    public class CreateProductSpecificationDto
    {
        public int ProductId { get; set; }

        public int ProductSpecificationCategoryId { get; set; }

        public int ProductSpecificationDetailId { get; set; }
    }
}
