using AutoMapper;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Exceptions;
using Wardakstudio.Services.ProductsAPI.Features.Producers.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Repository;

namespace Wardakstudio.Services.ProductsAPI.Features.Producers.Handlers.Commands
{
    public class DeleteProducerCommandHandler : IRequestHandler<DeleteProducerCommand, Unit>
    {
        private readonly IProducerRepository _repository;
        private readonly IMapper _mapper;

        public DeleteProducerCommandHandler(IProducerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProducerCommand request, CancellationToken cancellation)
        {
            var producerToDelete = await _repository.GetById(request.ProducerId);

            if (producerToDelete == null)
                throw new NotFoundException(nameof(Producer), request.ProducerId);

            await _repository.Delete(producerToDelete);

            return Unit.Value;
        }
    }
}
