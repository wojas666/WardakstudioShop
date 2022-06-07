using AutoMapper;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Features.ProductRatings.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Repository;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductRatings.Handlers.Commands
{
    public class DeleteProductRatingCommandHandler : IRequestHandler<DeleteProductRatingCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductRatingRepository _repository;

        public DeleteProductRatingCommandHandler(IMapper mapper, IProductRatingRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductRatingCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _repository.GetById(request.ProductRatingId);

            await _repository.Delete(productToDelete);

            return Unit.Value;
        }
    }
}
