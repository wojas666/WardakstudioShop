using FluentValidation;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductImage.Validators
{
    public class CreateProductImageDtoValidator : AbstractValidator<CreateProductImageDto>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductImageDtoValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            Include(new IProductImageDtoValidator(_productRepository));
        }


    }
}
