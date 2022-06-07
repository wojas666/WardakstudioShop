using MediatR;
using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Features.Products.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Repository;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product.Validators;
using Wardakstudio.Services.ProductsAPI.Exceptions;

namespace Wardakstudio.Services.ProductsAPI.Features.Products.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        private readonly IProducerRepository _producerRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public CreateProductCommandHandler(IMapper mapper, IProductRepository repository,
            IProducerRepository producerRepository,
            IProductCategoryRepository productCategoryRepository)
        {
            _mapper = mapper;
            _productRepository = repository;
            _producerRepository = producerRepository;
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductDtoValidator(_producerRepository, _productCategoryRepository);
            var validationResult = await validator.ValidateAsync(request.ProductDto);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var newProduct = _mapper.Map<Product>(request.ProductDto);

            newProduct = await _productRepository.Add(newProduct);

            return newProduct.Id;
        }
    }
}
