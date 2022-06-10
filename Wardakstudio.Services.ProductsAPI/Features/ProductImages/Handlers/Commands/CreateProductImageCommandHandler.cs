using MediatR;
using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Features.ProductImages.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductImage.Validators;
using Wardakstudio.Services.ProductsAPI.Responses;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductImages.Handlers.Commands
{
    public class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductImageRepository _repository;

        private readonly IProductRepository _productRepository;

        public CreateProductImageCommandHandler(IMapper mapper, IProductImageRepository repository,
            IProductRepository productRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _productRepository = productRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateProductImageCommand request, CancellationToken cancellation)
        {
            var validator = new CreateProductImageDtoValidator(_productRepository);
            var validationResult = await validator.ValidateAsync(request.ProductImageDto);

            var response = new BaseCommandResponse();

            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = "Creation of 'ProductImage' failed.";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var newProductImage = _mapper.Map<ProductImage>(request.ProductImageDto);
            newProductImage = await _repository.Add(newProductImage);

            response.IsSuccess = true;
            response.Message = "The creation of the 'ProductImage' was successful.";
            response.Id = newProductImage.Id;

            return response;
        }
    }
}
