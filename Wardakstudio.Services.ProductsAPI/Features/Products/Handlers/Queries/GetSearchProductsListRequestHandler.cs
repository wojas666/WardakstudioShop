using AutoMapper;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Features.Products.Requests.Queries;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product;
using Wardakstudio.Services.ProductsAPI.Repository;

namespace Wardakstudio.Services.ProductsAPI.Features.Products.Handlers.Queries
{
    public class GetSearchProductsListRequestHandler : IRequestHandler<GetSearchProductsListRequest, List<ProductDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;

        public GetSearchProductsListRequestHandler(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<ProductDto>> Handle(GetSearchProductsListRequest request, CancellationToken cancellation)
        {
            var searchedProducts = await _repository.GetSearchProductsList(request.SearchProduct);

            return _mapper.Map<List<ProductDto>>(searchedProducts);
        }
    }
}
