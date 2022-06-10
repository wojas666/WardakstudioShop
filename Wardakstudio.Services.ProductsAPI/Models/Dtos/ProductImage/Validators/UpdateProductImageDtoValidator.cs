using FluentValidation;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductImage.Validators
{
    public class UpdateProductImageDtoValidator : AbstractValidator<UpdateProductImageDto>
    {
        private readonly IProductRepository _repository;

        public UpdateProductImageDtoValidator(IProductRepository repository)
        {
            _repository = repository;

            Include(new IProductImageDtoValidator(_repository));
        }
    }
}
