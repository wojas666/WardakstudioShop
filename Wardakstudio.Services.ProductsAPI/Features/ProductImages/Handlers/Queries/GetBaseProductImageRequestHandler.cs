using AutoMapper;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Features.ProductImages.Requests.Queries;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductImage;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductImages.Handlers.Queries
{
    public class GetBaseProductImageRequestHandler : IRequestHandler<GetBaseProductImageRequest, ProductImageDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductImageRepository _repository;

        public GetBaseProductImageRequestHandler(IMapper mapper, IProductImageRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ProductImageDto> Handle(GetBaseProductImageRequest request, CancellationToken cancellation)
        {
            var baseImageForProduct = await _repository.GetBaseProductImageForProduct(request.ProductId);

            return _mapper.Map<ProductImageDto>(baseImageForProduct);
        }
    }
}
