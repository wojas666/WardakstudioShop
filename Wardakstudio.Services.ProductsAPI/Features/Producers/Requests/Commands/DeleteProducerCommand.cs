using MediatR;

namespace Wardakstudio.Services.ProductsAPI.Features.Producers.Requests.Commands
{
    public class DeleteProducerCommand : IRequest
    {
        public int ProducerId { get; set; }
    }
}
