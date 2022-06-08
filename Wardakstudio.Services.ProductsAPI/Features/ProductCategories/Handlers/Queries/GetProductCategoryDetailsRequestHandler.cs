using MediatR;
using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Features.ProductCategories.Requests.Queries;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductCategory;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductCategories.Handlers.Queries
{
    public class GetProductCategoryDetailsRequestHandler : IRequestHandler<GetProductCategoryDetailsRequest, ProductCategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductCategoryRepository _repository;

        public GetProductCategoryDetailsRequestHandler(IMapper mapper, IProductCategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;   
        }

        public async Task<ProductCategoryDto> Handle(GetProductCategoryDetailsRequest request, CancellationToken cancellation)
        {
            var productCategoryDetails = await _repository.GetById(request.Id);

            return _mapper.Map<ProductCategoryDto>(productCategoryDetails);
        }
    }
}
