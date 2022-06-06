using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer;

namespace Wardakstudio.Services.ProductsAPI.Features.Producers.Requests.Queries
{
    public class GetProducerDetailsRequest : IRequest<ProducerDto>
    {
        public int Id { get; set; }
    }
}
