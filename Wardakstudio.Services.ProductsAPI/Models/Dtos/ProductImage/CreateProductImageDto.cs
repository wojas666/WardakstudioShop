using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductImage
{
    public class CreateProductImageDto : IProductImageDto
    {
        public string ImageUrl { get; set; }

        public int ProductId { get; set; }

        public bool IsBase { get; set; }

        public bool IsPublished { get; set; }

    }
}
