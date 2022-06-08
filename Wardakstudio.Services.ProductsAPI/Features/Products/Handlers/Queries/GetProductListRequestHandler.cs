using AutoMapper;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Features.Products.Requests.Queries;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Features.Products.Handlers.Queries
{
    public class GetProductListRequestHandler : IRequestHandler<GetProductsListRequest, List<ProductDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;

        public GetProductListRequestHandler(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<ProductDto>> Handle(GetProductsListRequest request, CancellationToken cancellation)
        {
            var productList = await _repository.GetAll();

            return _mapper.Map<List<ProductDto>>(productList);
        }
    }
}
