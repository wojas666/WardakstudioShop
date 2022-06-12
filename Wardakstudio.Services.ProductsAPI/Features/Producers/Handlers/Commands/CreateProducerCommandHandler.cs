using MediatR;
using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Features.Producers.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer.Validators;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;
using Wardakstudio.Services.ProductsAPI.Responses; 

namespace Wardakstudio.Services.ProductsAPI.Features.Producers.Handlers.Commands
{
    public class CreateProducerCommandHandler : IRequestHandler<CreateProducerCommand, BaseCommandResponse>
    {
        private readonly IProducerRepository _producerRepository;
        private readonly IMapper _mapper;

        public CreateProducerCommandHandler(IProducerRepository producerRepository, IMapper mapper)
        {
            _producerRepository = producerRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateProducerCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProducerValidator();
            var validationResult = await validator.ValidateAsync(request.ProducerDto);
            BaseCommandResponse response = new BaseCommandResponse();

            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = "Nie udało się utworzyć nowego producenta.";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var newProducer = _mapper.Map<Producer>(request.ProducerDto);
            newProducer = await _producerRepository.Add(newProducer);

            response.Id = newProducer.Id;
            response.IsSuccess = true;
            response.Message = "Nowy producent utworzony pomyślnie.";

            return response;
        }
    }
}
