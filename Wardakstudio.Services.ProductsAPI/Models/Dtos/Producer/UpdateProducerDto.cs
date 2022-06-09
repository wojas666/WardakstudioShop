using Wardakstudio.Services.ProductsAPI.Models.Dtos.Common;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer
{
    public class UpdateProducerDto : BaseDto, IProducerDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

    }
}
