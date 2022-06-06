namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int AvailableQuantity { get; set; }

        public int ProductCategoryId { get; set; }

        public int ProducerId { get; set; }

        public bool IsPublished { get; set; }
    }
}
