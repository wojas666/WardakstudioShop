using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductRating;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductRatings.Requests.Queries
{
    public class GetProductRatingsListRequest : IRequest<List<ProductRatingDto>>
    {
        public int ProductId { get; set; }
    }
}
