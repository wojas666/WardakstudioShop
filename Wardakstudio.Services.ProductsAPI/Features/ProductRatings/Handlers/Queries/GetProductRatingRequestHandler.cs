using AutoMapper;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Features.ProductRatings.Requests.Queries;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductRating;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductRatings.Handlers.Queries
{
    public class GetProductRatingRequestHandler : IRequestHandler<GetProductRatingRequest, ProductRatingDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductRatingRepository _repository;

        public GetProductRatingRequestHandler(IMapper mapper, IProductRatingRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ProductRatingDto> Handle(GetProductRatingRequest request, CancellationToken cancellationToken)
        {
            var productRating = await _repository.GetById(request.ProductRatingId);

            return _mapper.Map<ProductRatingDto>(productRating);
        }
    }
}
