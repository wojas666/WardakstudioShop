using FluentValidation;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductCategory.Validators
{
    public class CreateProductCategoryDtoValidator : AbstractValidator<CreateProductCategoryDto>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public CreateProductCategoryDtoValidator(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;

            Include(new IProductCategoryDtoValidator(_productCategoryRepository));
        }
    }
}
