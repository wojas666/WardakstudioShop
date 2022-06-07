using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer;

namespace Wardakstudio.Services.ProductsAPI.Features.Producers.Requests.Commands
{
    public class CreateProducerCommand : IRequest<int>
    {
        public CreateProducerDto ProducerDto { get; set; }

    }
}
