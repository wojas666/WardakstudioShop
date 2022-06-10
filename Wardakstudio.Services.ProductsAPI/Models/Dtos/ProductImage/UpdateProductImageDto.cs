using Wardakstudio.Services.ProductsAPI.Models.Dtos.Common;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductImage
{
    public class UpdateProductImageDto : BaseDto, IProductImageDto
    {
        public string ImageUrl { get; set; }

        public int ProductId { get; set; }

        public bool IsBase { get; set; }

        public bool IsPublished { get; set; }
    }
}
