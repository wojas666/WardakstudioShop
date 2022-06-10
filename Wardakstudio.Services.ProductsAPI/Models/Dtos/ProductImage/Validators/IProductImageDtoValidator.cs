using FluentValidation;
using Wardakstudio.Services.ProductsAPI.Extensions;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductImage.Validators
{
    public class IProductImageDtoValidator : AbstractValidator<IProductImageDto>
    {
        private readonly IProductRepository _productRepository;

        public IProductImageDtoValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustUrl().WithMessage("{PropertyName} must be a url.");

            RuleFor(x => x.ProductId)
                .NotNull().WithMessage("{PropertyName} is required.")
                .MustAsync(async (id, token) =>
                {
                    var productExists = await _productRepository.Exists(id);
                    return !productExists;
                });
        }


    }
}
