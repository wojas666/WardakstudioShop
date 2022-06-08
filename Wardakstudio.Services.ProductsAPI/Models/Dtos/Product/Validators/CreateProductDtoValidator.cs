using FluentValidation;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.Product.Validators
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        private readonly IProducerRepository _producerRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public CreateProductDtoValidator(IProducerRepository producerRepository, IProductCategoryRepository productCategoryRepository)
        {
            _producerRepository = producerRepository;
            _productCategoryRepository = productCategoryRepository;

            Include(new IProductDtoValidator(producerRepository, productCategoryRepository));
        }
    }
}
