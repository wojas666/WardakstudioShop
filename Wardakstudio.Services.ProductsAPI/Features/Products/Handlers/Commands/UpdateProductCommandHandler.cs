using MediatR;
using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Models.Dtos;
using Wardakstudio.Services.ProductsAPI.Features.Products.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Exceptions;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product.Validators;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Features.Products.Handlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;

        private readonly IProducerRepository _producerRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public UpdateProductCommandHandler(IMapper mapper, IProductRepository repository,
            IProducerRepository producerRepository,
            IProductCategoryRepository productCategoryRepository)
        {
            _mapper = mapper;
            _repository = repository;

            _producerRepository = producerRepository;
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(request.ProductId);

            if (product == null)
                throw new NotFoundException(nameof(Product), request.ProductId);

            if (request.ProductToUpdate is not null)
            {
                var validator = new UpdateProductDtoValidator(_producerRepository, _productCategoryRepository);
                var validationResult = await validator.ValidateAsync(request.ProductToUpdate);

                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult);

                product = _mapper.Map<Product>(request.ProductToUpdate);

                await _repository.Update(product);
            }
            else if(request.ChangeProductPublishedStatusDto is not null)
            {
                await _repository.ChangeProductPublishedStatus(product, request.ChangeProductPublishedStatusDto.IsPublished);
            }

            return Unit.Value;
        }
    }
}
