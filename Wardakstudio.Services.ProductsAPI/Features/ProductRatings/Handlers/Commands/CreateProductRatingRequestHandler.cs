using AutoMapper;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Features.ProductRatings.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Repository;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductRatings.Handlers.Commands
{
    public class CreateProductRatingRequestHandler : IRequestHandler<CreateProductRatingRequest, int>
    {
        private readonly IMapper _mapper;
        private readonly IProductRatingRepository _repository;

        public CreateProductRatingRequestHandler(IMapper mapper, IProductRatingRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Handle(CreateProductRatingRequest request, CancellationToken cancellation)
        {
            var newProductRating = _mapper.Map<ProductRating>(request.ProductRatingDto);

            newProductRating = await _repository.Add(newProductRating);

            return newProductRating.Id;
        }
    }
}
