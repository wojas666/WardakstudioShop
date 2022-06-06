using AutoMapper;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Features.ProductImages.Requests.Queries;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductImage;
using Wardakstudio.Services.ProductsAPI.Repository;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductImages.Handlers.Queries
{
    public class GetProductImageDetailsRequestHandler : IRequestHandler<GetProductImageDetailsRequest, ProductImageDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductImageRepository _repository;

        public GetProductImageDetailsRequestHandler(IMapper mapper, IProductImageRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ProductImageDto> Handle(GetProductImageDetailsRequest request, CancellationToken cancellation)
        {
            var productImageDetails = await _repository.GetById(request.Id);

            return _mapper.Map<ProductImageDto>(productImageDetails);
        }
    }
}
