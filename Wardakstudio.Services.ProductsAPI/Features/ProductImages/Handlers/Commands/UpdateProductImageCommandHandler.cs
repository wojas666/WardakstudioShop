using AutoMapper;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Features.ProductImages.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;
using Wardakstudio.Services.ProductsAPI.Exceptions;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductImage.Validators;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductImages.Handlers.Commands
{
    public class UpdateProductImageCommandHandler : IRequestHandler<UpdateProductImageCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductImageRepository _repository;
        private readonly IProductRepository _productRepository;

        public UpdateProductImageCommandHandler(IMapper mapper, IProductImageRepository repository,
            IProductRepository productRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(UpdateProductImageCommand request, CancellationToken cancellationToken)
        {
            var productImage = await _repository.GetById(request.ProductImageId);

            if (productImage == null)
                throw new NotFoundException(nameof(ProductImage), request.ProductImageId);

            if(request.ImageToUpdate != null)
            {
                var validator = new UpdateProductImageDtoValidator(_productRepository);
                var validationResult = await validator.ValidateAsync(request.ImageToUpdate);

                if (!validationResult.IsValid)
                    throw new ValidationException(validationResult);

                productImage = _mapper.Map<ProductImage>(request.ImageToUpdate);

                await _repository.Update(productImage);
            }
            else if(request.ChangeProductImagePublishedStatusDto != null)
            {
                await _repository.ChangeProductImagePublishedStatus(productImage, request.ChangeProductImagePublishedStatusDto.IsPublished);
            }
            else if(request.ChangeBaseProductImageDto != null)
            {
                await _repository.ChangeBaseProductImage(productImage, request.ChangeBaseProductImageDto.IsBase);
            }

            return Unit.Value;
        }
    }
}
