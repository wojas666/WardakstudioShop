﻿using MediatR;
using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Features.Producers.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Repository;
using Wardakstudio.Services.ProductsAPI.Models;

namespace Wardakstudio.Services.ProductsAPI.Features.Producers.Handlers.Commands
{
    public class CreateProducerRequestHandler : IRequestHandler<CreateProducerRequest, int>
    {
        private readonly IProducerRepository _producerRepository;
        private readonly IMapper _mapper;

        public CreateProducerRequestHandler(IProducerRepository producerRepository, IMapper mapper)
        {
            _producerRepository = producerRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProducerRequest request, CancellationToken cancellationToken)
        {
            var newProducer = _mapper.Map<Producer>(request.ProducerDto);

            newProducer = await _producerRepository.Add(newProducer);

            return newProducer.Id;
        }
    }
}
