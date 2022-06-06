using AutoMapper;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Features.ProductSpecificationCategories.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Repository;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductSpecificationCategories.Handles.Commands
{
    public class CreateProductSpecificationCategoryRequestHandler : IRequestHandler<CreateProductSpecificationCategoryRequest, int>
    {
        private readonly IProductSpecificationCategoryRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductSpecificationCategoryRequestHandler(IProductSpecificationCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProductSpecificationCategoryRequest request, CancellationToken cancellation)
        {
            var newPoductSpecificationCategory = _mapper.Map<ProductSpecificationCategory>(request.ProductSpecificationCategoryDto);
            newPoductSpecificationCategory = await _repository.Add(newPoductSpecificationCategory);

            return newPoductSpecificationCategory.Id;
        }
    }
}
