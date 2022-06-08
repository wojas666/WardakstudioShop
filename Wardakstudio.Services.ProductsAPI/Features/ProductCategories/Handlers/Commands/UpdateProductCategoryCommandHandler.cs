using AutoMapper;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Exceptions;
using Wardakstudio.Services.ProductsAPI.Features.ProductCategories.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductCategory.Validators;
using Wardakstudio.Services.ProductsAPI.Repository;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductCategories.Handlers.Commands
{
    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductCategoryRepository _repository;

        public UpdateProductCategoryCommandHandler(IMapper mapper, IProductCategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductCategoryDtoValidator(_repository);
            var validationResult = await validator.ValidateAsync(request.ProductCategoryUpdate);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var productCategory = _mapper.Map<ProductCategory>(request.ProductCategoryUpdate);
            await _repository.Update(productCategory);

            return Unit.Value;
        }
    }
}
