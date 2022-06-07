using MediatR;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductRatings.Requests.Commands
{
    public class DeleteProductRatingCommand : IRequest
    {
        public int ProductRatingId { get; set; }
    }
}
