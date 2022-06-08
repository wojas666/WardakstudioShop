using FluentValidation;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductCategory.Validators
{
    public class UpdateProductCategoryDtoValidator : AbstractValidator<UpdateProductCategoryDto>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public UpdateProductCategoryDtoValidator(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;

            Include(new IProductCategoryDtoValidator(_productCategoryRepository));

            RuleFor(x => x.Id)
                .NotNull().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}");
        }
    }
}
