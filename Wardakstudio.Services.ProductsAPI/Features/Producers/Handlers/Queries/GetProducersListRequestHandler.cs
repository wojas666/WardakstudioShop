using MediatR;
using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Features.Producers;
using Wardakstudio.Services.ProductsAPI.Repository;
using Wardakstudio.Services.ProductsAPI.Features.Producers.Requests.Queries;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer;

namespace Wardakstudio.Services.ProductsAPI.Features.Producers.Handlers.Queries
{
    public class GetProducersListRequestHandler : IRequestHandler<GetProducersListRequest, List<ProducerDto>>
    {
        private readonly IProducerRepository _producerRepository;
        private readonly IMapper _mapper;

        public GetProducersListRequestHandler(IProducerRepository producerRepository, IMapper mapper)
        {
            _producerRepository = producerRepository;
            _mapper = mapper;
        }

        public async Task<List<ProducerDto>> Handle(GetProducersListRequest request, CancellationToken cancellationToken)
        {
            var producers = await _producerRepository.GetAll();
            return _mapper.Map<List<ProducerDto>>(producers);
        }
    }
}
