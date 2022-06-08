using FluentValidation;
using Wardakstudio.Services.ProductsAPI.Extensions;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductCategory.Validators
{
    public class IProductCategoryDtoValidator : AbstractValidator<IProductCategoryDto>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public IProductCategoryDtoValidator(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;

            RuleFor(x => x.CategoryName)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.CategoryUrlSeo)
                .NotNull().WithMessage("{PropertyName} is required.")
                .MustSeoFriendly().WithMessage("{PropertyName} is not seo friendly. Do not use special characters, spaces or numbers, and separate words with '-'.")
                .MustSectionPartialUrl().WithMessage("{PropertyName} is not section partial url. Your section partial url should start and end with '/', the number of '/' characters should be exactly 2.");

            RuleFor(x => x.ParentCategoryId)
                .MustAsync(async (id, token) =>
                {
                    if (id is null)
                        return true;

                    var parentCategoryExists = await _productCategoryRepository.Exists((int)id);
                    return !parentCategoryExists;
                }).WithMessage("{PropertyName} is not exists 'ProductCategory' table.");

        }
    }
}
