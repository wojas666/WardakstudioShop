using MediatR;
using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Features.ProductImages.Requests;
using Wardakstudio.Services.ProductsAPI.Repository;
using Wardakstudio.Services.ProductsAPI.Features.ProductImages.Requests.Queries;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductImage;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductImages.Handlers.Queries
{
    public class GetProductImagesListRequestHandler : IRequestHandler<GetProductImagesListRequest, List<ProductImageDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductImageRepository _repository;

        public GetProductImagesListRequestHandler(IMapper mapper, IProductImageRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<ProductImageDto>> Handle(GetProductImagesListRequest request, CancellationToken cancellation)
        {
            var productImagesForProduct = await _repository.GetProductImagesListForProduct(request.ProductId);

            return _mapper.Map<List<ProductImageDto>>(productImagesForProduct);
        }
    }
}
