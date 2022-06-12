using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer;
using Wardakstudio.Services.ProductsAPI.Responses;

namespace Wardakstudio.Services.ProductsAPI.Features.Producers.Requests.Commands
{
    public class CreateProducerCommand : IRequest<BaseCommandResponse>
    {
        public CreateProducerDto ProducerDto { get; set; }
    }
}
