using Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer.Validators;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer
{
    public class CreateProducerDto : IProducerDto
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
