using AutoMapper;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Features.ProductRatings.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductRatings.Handlers.Commands
{
    public class CreateProductRatingCommandHandler : IRequestHandler<CreateProductRatingCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IProductRatingRepository _repository;

        public CreateProductRatingCommandHandler(IMapper mapper, IProductRatingRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Handle(CreateProductRatingCommand request, CancellationToken cancellation)
        {
            var newProductRating = _mapper.Map<ProductRating>(request.ProductRatingDto);

            newProductRating = await _repository.Add(newProductRating);

            return newProductRating.Id;
        }
    }
}
