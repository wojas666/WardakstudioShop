using Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductCategory;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecification;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.Product
{
    public class SearchProductDto
    {
        public string? Name { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public ProductCategoryDto? ProductCategory { get; set; }

        public ICollection<ProducerDto>? Producer { get; set; }

        public ICollection<ProductSpecificationDto>? ProductSpecifications { get; set; }

        public bool IsAvailable { get; set; } = false;

        public SortType SortType { get; set; }
    }

    public enum SortType
    {
        LowPrice,
        HighPrice,
        BestRating,
        MostPopular
    }
}
