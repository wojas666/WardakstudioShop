using AutoMapper;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Features.ProductImages.Requests.Queries;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductImage;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductImages.Handlers.Queries
{
    public class GetAllProductsImagesListRequestHandler : IRequestHandler<GetAllProductsImagesListRequest, List<ProductImageDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductImageRepository _repository;

        public GetAllProductsImagesListRequestHandler(IMapper mapper, IProductImageRepository repository)
        {
            _mapper = mapper;
            _repository = repository;   
        }

        public async Task<List<ProductImageDto>> Handle(GetAllProductsImagesListRequest request, CancellationToken cancellation)
        {
            var allProductsImagesList = await _repository.GetAll();

            return _mapper.Map<List<ProductImageDto>>(allProductsImagesList);
        }
    }
}
