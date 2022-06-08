using MediatR;
using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Features.Products.Requests.Queries;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product;
using Wardakstudio.Services.ProductsAPI.Exceptions;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Features.Products.Handlers.Queries
{
    public class GetProductDetailsRequestHandler : IRequestHandler<GetProductDetailsRequest, ProductDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;

        public GetProductDetailsRequestHandler(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ProductDto> Handle(GetProductDetailsRequest request, CancellationToken cancellation)
        {
            var productDetails = await _repository.GetById(request.Id);

            if (productDetails == null)
                throw new NotFoundException(nameof(Product), request.Id);

            return _mapper.Map<ProductDto>(productDetails);
        }
    }
}
