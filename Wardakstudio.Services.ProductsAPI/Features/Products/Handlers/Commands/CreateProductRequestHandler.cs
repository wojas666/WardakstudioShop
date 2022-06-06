using MediatR;
using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Features.Products.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Repository;

namespace Wardakstudio.Services.ProductsAPI.Features.Products.Handlers.Commands
{
    public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, int>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public CreateProductRequestHandler(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _productRepository = repository;
        }

        public async Task<int> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var newProduct = _mapper.Map<Product>(request.ProductDto);

            newProduct = await _productRepository.Add(newProduct);

            return newProduct.Id;
        }
    }
}
