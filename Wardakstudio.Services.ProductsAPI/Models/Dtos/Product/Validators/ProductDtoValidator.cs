using FluentValidation;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.Product.Validators
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        private readonly IProducerRepository _producerRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductDtoValidator(IProducerRepository producerRepository, 
            IProductCategoryRepository productCategoryRepository)
        {
            _producerRepository = producerRepository;
            _productCategoryRepository = productCategoryRepository;

            Include(new IProductDtoValidator(_producerRepository, _productCategoryRepository));

        }
    }
}
