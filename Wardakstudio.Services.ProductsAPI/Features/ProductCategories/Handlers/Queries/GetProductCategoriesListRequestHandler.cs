

using AutoMapper;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Features.ProductCategories.Requests.Queries;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductCategory;
using Wardakstudio.Services.ProductsAPI.Repository;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductCategories.Handlers.Queries
{
    public class GetProductCategoriesListRequestHandler : IRequestHandler<GetProductCategoriesListRequest,List<ProductCategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductCategoryRepository _repository;

        public GetProductCategoriesListRequestHandler(IMapper mapper, IProductCategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<ProductCategoryDto>> Handle(GetProductCategoriesListRequest request, CancellationToken cancellation)
        {
            var productCategoriesList = await _repository.GetAll();

            return _mapper.Map<List<ProductCategoryDto>>(productCategoriesList);
        }
    }
}
