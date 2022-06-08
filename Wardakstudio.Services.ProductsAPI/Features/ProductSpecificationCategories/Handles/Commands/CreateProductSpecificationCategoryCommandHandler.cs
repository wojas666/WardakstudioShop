using AutoMapper;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Features.ProductSpecificationCategories.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductSpecificationCategories.Handles.Commands
{
    public class CreateProductSpecificationCategoryCommandHandler : IRequestHandler<CreateProductSpecificationCategoryCommand, int>
    {
        private readonly IProductSpecificationCategoryRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductSpecificationCategoryCommandHandler(IProductSpecificationCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProductSpecificationCategoryCommand request, CancellationToken cancellation)
        {
            var newPoductSpecificationCategory = _mapper.Map<ProductSpecificationCategory>(request.ProductSpecificationCategoryDto);
            newPoductSpecificationCategory = await _repository.Add(newPoductSpecificationCategory);

            return newPoductSpecificationCategory.Id;
        }
    }
}
