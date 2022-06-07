using MediatR;
using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Features.ProductCategories.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Repository;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductCategories.Handlers.Commands
{
    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IProductCategoryRepository _repository;

        public CreateProductCategoryCommandHandler(IMapper mapper, IProductCategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Handle (CreateProductCategoryCommand request, CancellationToken cancel)
        {
            var newCategory = _mapper.Map<ProductCategory>(request.ProductCategoryDto);

            newCategory = await _repository.Add(newCategory);

            return newCategory.Id;
        }
    }
}
