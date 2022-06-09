using FluentValidation;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer.Validators
{
    public class UpdateProducerValidator : AbstractValidator<UpdateProducerDto>
    {
        private readonly IProducerRepository _producerRepository;

        public UpdateProducerValidator(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;

            Include(new IProducerDtoValidator());

            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}")
                .MustAsync(async (id, token) =>
                {
                    var producerExist = await _producerRepository.Exists(id);
                    return !producerExist;
                }).WithMessage("{PropertyName} does not correspond to any record in the 'Producers' table.");
        }
    }
}
