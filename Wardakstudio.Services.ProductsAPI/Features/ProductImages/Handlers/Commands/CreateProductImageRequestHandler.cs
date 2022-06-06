using MediatR;
using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Features.ProductImages.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Repository;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductImages.Handlers.Commands
{
    public class CreateProductImageRequestHandler : IRequestHandler<CreateProductImageRequest, int>
    {
        private readonly IMapper _mapper;
        private readonly IProductImageRepository _repository;

        public CreateProductImageRequestHandler(IMapper mapper, IProductImageRepository repository)
        {
            _mapper = mapper;
            _repository = repository;   
        }

        public async Task<int> Handle(CreateProductImageRequest request, CancellationToken cancellation)
        {
            var newProductImage = _mapper.Map<ProductImage>(request.ProductImageDto);
            newProductImage = await _repository.Add(newProductImage);

            return newProductImage.Id;
        }
    }
}
