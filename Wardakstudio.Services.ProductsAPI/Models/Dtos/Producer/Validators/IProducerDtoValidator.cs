using FluentValidation;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer.Validators
{
    public class IProducerDtoValidator : AbstractValidator<IProducerDto>
    {
        public IProducerDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("{PropertyName} is null.")
                .NotEmpty().WithMessage("{PropertyName} is empty.")
                .MaximumLength(100).WithMessage("{PropertyName} cannot be longer than {ComparisonValue} characters.");

            RuleFor(x => x.Description)
                .NotNull().WithMessage("{ PropertyName} is null.")
                .NotEmpty().WithMessage("{PropertyName} is empty.")
                .MinimumLength(50).WithMessage("{PropertyName} cannot be shorter than {ComparisonValue} characters");
        }
    }
}
