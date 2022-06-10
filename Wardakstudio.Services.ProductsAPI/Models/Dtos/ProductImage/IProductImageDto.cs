namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductImage
{
    public interface IProductImageDto
    {
        public string ImageUrl { get; set; }

        public int ProductId { get; set; }

        public bool IsBase { get; set; }

        public bool IsPublished { get; set; }
    }
}
