using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer;

namespace Wardakstudio.Services.ProductsAPI.Features.Producers.Requests.Queries
{
    public class GetProducersListRequest : IRequest<List<ProducerDto>>
    {

    }
}
