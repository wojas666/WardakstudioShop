using Wardakstudio.Services.ProductsAPI.Models.Dtos.Common;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer.Validators;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer
{
    public class ProducerDto : BaseDto, IProducerDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<ProductDto> Products { get; set; }
    }
}
