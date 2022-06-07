using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductRating;


namespace Wardakstudio.Services.ProductsAPI.Features.ProductRatings.Requests.Commands
{
    public class UpdateProductCommand : IRequest
    {
        public int ProductRatingId { get; set; }

        public ProductRatingDto UpdateProductRating { get; set; }

        public ChangeApprovalStatusDto ChangeApprovalStatus { get; set; }
    }
}
