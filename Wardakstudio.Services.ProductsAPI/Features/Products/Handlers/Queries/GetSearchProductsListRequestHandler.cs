using AutoMapper;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Exceptions;
using Wardakstudio.Services.ProductsAPI.Features.Products.Requests.Queries;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product.Validators;
using Wardakstudio.Services.ProductsAPI.Repository;

namespace Wardakstudio.Services.ProductsAPI.Features.Products.Handlers.Queries
{
    public class GetSearchProductsListRequestHandler : IRequestHandler<GetSearchProductsListRequest, List<ProductDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;

        private readonly IProducerRepository _producerRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public GetSearchProductsListRequestHandler(IMapper mapper, IProductRepository repository,
            IProducerRepository producerRepository,
            IProductCategoryRepository productCategoryRepository)
        {
            _mapper = mapper;
            _repository = repository;

            _producerRepository = producerRepository;
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<List<ProductDto>> Handle(GetSearchProductsListRequest request, CancellationToken cancellation)
        {
            var validator = new SearchProductDtoValidator(_producerRepository, _productCategoryRepository);
            var validationResult = await validator.ValidateAsync(request.SearchProduct);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var searchedProducts = await _repository.GetSearchProductsList(request.SearchProduct);

            return _mapper.Map<List<ProductDto>>(searchedProducts);
        }
    }
}
