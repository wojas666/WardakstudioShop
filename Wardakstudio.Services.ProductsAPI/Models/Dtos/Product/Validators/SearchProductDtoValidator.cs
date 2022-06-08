using FluentValidation;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.Product.Validators
{
    public class SearchProductDtoValidator : AbstractValidator<SearchProductDto>
    {
        private readonly IProducerRepository _producerRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public SearchProductDtoValidator(IProducerRepository producerRepository, 
            IProductCategoryRepository productCategoryRepository)
        {
            _producerRepository = producerRepository;
            _productCategoryRepository = productCategoryRepository;

            RuleForEach(x => x.ProducerIds)
                .MustAsync(async (id, token) =>
                {
                    var producerExists = await _producerRepository.Exists(id);
                    return !producerExists;
                }).WithMessage("Jeden z wybranych producentów nie istnieje!");

            RuleForEach(x => x.ProductCategoryIds)
                .MustAsync(async (id, token) =>
                {
                    var productCategoryExists = await _productCategoryRepository.Exists(id);
                    return !productCategoryExists;
                }).WithMessage("Jedna z podanych kategorii nie istnieje!");

            RuleFor(x => x.MaxPrice)
                .GreaterThan(y => y.MinPrice).WithMessage("Cena maksymalna nie może być mniejsza od ceny minimalnej.");

            RuleFor(x => x.MinPrice)
                .LessThan(y => y.MaxPrice).WithMessage("Cena minimalna nie może być wyższa od ceny maksymalnej.");

        }
    }
}
