using MediatR;
using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Features.ProductImages.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductImages.Handlers.Commands
{
    public class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IProductImageRepository _repository;

        public CreateProductImageCommandHandler(IMapper mapper, IProductImageRepository repository)
        {
            _mapper = mapper;
            _repository = repository;   
        }

        public async Task<int> Handle(CreateProductImageCommand request, CancellationToken cancellation)
        {
            var newProductImage = _mapper.Map<ProductImage>(request.ProductImageDto);
            newProductImage = await _repository.Add(newProductImage);

            return newProductImage.Id;
        }
    }
}
