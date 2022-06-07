using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductRating;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductRatings.Requests.Queries
{
    public class GetProductRatingRequest : IRequest<ProductRatingDto>
    {
        public int ProductRatingId { get; set; }
    }
}
