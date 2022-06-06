using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer;

namespace Wardakstudio.Services.ProductsAPI.Features.Producers.Requests.Commands
{
    public class CreateProducerRequest : IRequest<int>
    {
        public CreateProducerDto ProducerDto { get; set; }

    }
}
