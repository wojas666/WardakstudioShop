using MediatR;
using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Features.ProductRatings.Requests.Queries;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductRating;
using Wardakstudio.Services.ProductsAPI.Repository;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductRatings.Handlers.Queries
{
    public class GetProductRatingsListRequestHandler : IRequestHandler<GetProductRatingsListRequest, List<ProductRatingDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRatingRepository _repository;

        public GetProductRatingsListRequestHandler(IMapper mapper, IProductRatingRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<ProductRatingDto>> Handle(GetProductRatingsListRequest request, CancellationToken cancellationToken)
        {
            var productRatings = await _repository.GetProductRatings(request.ProductId);

            return _mapper.Map<List<ProductRatingDto>>(productRatings);
        }
    }
}
