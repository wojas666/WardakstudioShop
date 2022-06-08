using FluentValidation;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer.Validators
{
    public class CreateProducerValidator : AbstractValidator<CreateProducerDto>
    {
        public CreateProducerValidator()
        {
            Include(new IProducerDtoValidator());
        }
    }
}
