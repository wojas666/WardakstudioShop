using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductRating;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductRatings.Requests.Commands
{
    public class CreateProductRatingCommand : IRequest<int>
    {
        public CreateProductRatingDto ProductRatingDto { get; set; }
    }
}
