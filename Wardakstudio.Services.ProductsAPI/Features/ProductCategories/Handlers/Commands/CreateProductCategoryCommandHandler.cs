using MediatR;
using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Features.ProductCategories.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Repository;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductCategory.Validators;
using Wardakstudio.Services.ProductsAPI.Responses;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductCategories.Handlers.Commands
{
    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductCategoryRepository _repository;

        public CreateProductCategoryCommandHandler(IMapper mapper, IProductCategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<BaseCommandResponse> Handle (CreateProductCategoryCommand request, CancellationToken cancel)
        {
            BaseCommandResponse response = new BaseCommandResponse();

            var validator = new CreateProductCategoryDtoValidator(_repository);
            var validationResult = await validator.ValidateAsync(request.ProductCategoryDto);

            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = "Utworzenie nowej kategorii nie powiodło się.";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var newCategory = _mapper.Map<ProductCategory>(request.ProductCategoryDto);

            newCategory = await _repository.Add(newCategory);

            response.Message = "Utworzono nową kategorię.";
            response.IsSuccess = true;
            response.Id = newCategory.Id;

            return response;
        }
    }
}
