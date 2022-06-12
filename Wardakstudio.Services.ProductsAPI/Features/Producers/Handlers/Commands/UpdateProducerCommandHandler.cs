using AutoMapper;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Exceptions;
using Wardakstudio.Services.ProductsAPI.Features.Producers.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer.Validators;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Features.Producers.Handlers.Commands
{
    public class UpdateProducerCommandHandler : IRequestHandler<UpdateProducerCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProducerRepository _repository;

        public UpdateProducerCommandHandler(IMapper mapper, IProducerRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProducerCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProducerValidator(_repository);
            var validationResult = await validator.ValidateAsync(request.ProducerToUpdate);

            if(!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var producerToUpdate = _mapper.Map<Producer>(request.ProducerToUpdate);
            await _repository.Update(producerToUpdate);

            return Unit.Value;
        }
    }
}
