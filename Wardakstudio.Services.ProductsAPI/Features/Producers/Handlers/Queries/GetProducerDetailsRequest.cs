using MediatR;
using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Features.Producers.Requests.Queries;
using Wardakstudio.Services.ProductsAPI.Repository;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer;

namespace Wardakstudio.Services.ProductsAPI.Features.Producers.Handlers.Queries
{
    public class GetProducerDetailsRequestHandler : IRequestHandler<GetProducerDetailsRequest, ProducerDto>
    {
        private readonly IMapper _mapper;
        private readonly IProducerRepository _repository;

        public GetProducerDetailsRequestHandler(IMapper mapper, IProducerRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ProducerDto> Handle(GetProducerDetailsRequest request, CancellationToken cancellation)
        {
            var producerDetails = await _repository.GetById(request.Id);

            return _mapper.Map<ProducerDto>(producerDetails);
        }
    }
}
