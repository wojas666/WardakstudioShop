using MediatR;
using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Features.ProductRatings.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductRatings.Handlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductRatingRepository _repository;

        public UpdateProductCommandHandler(IMapper mapper, IProductRatingRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellation)
        {
            var productRating = await _repository.GetById(request.ProductRatingId);

            if(request.UpdateProductRating is not null)
            {
                productRating = _mapper.Map<ProductRating>(request.UpdateProductRating);

                await _repository.Update(productRating);
            } else if(request.ChangeApprovalStatus is not null)
            {
                await _repository.ChangeApprovalStatus(productRating, request.ChangeApprovalStatus.IsApproved);
            }

            return Unit.Value;
        }
    }
}
