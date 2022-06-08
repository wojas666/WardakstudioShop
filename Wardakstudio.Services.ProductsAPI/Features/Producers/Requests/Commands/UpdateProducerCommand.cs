using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer;

namespace Wardakstudio.Services.ProductsAPI.Features.Producers.Requests.Commands
{
    public class UpdateProducerCommand : IRequest
    {
        public ProducerDto ProducerToUpdate { get; set; }
    }
}
