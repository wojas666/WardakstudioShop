using FluentValidation;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.Product.Validators
{
    public class IProductDtoValidator : AbstractValidator<IProductDto>
    {
        private readonly IProducerRepository _producerRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public IProductDtoValidator(IProducerRepository producerRepository, IProductCategoryRepository productCategoryRepository)
        {
            _producerRepository = producerRepository;
            _productCategoryRepository = productCategoryRepository;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nazwa produktu jest wymagana.")
                .NotNull()
                .MaximumLength(100).WithMessage("Nazwa produktu nie może być dłuższa niż {ComparisonValue} znaków.");

            RuleFor(x => x.Price)
                .NotNull().WithMessage("Cena jest wymagana.")
                .GreaterThan(0);

            RuleFor(x => x.ProducerId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var producerExist = await _producerRepository.Exists(id);
                    return producerExist;
                }).WithMessage("Producent o podanym {PropertyName} nie istnieje.");

            RuleFor(x => x.ProductCategoryId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var productCategoryExist = await _productCategoryRepository.Exists(id);
                    return productCategoryExist;
                }).WithMessage("Kategoria o podanym {PropertyName} nie istnieje.");

            RuleFor(x => x.Description)
                .MinimumLength(50).WithMessage("Opis produktu nie może być krótszy niż {ComparisonValue} znaków.")
                .MaximumLength(15000).WithMessage("Opis produktu nie może być dłuższy niż {ComparisonValue} znaków");
        }
    }
}
