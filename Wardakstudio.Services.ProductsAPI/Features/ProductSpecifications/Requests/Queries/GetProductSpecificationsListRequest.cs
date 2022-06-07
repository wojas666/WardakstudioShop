using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecification;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductSpecifications.Requests.Queries
{
    public class GetProductSpecificationsListRequest : IRequest<List<ProductSpecificationDto>>
    {
        public int ProductId { get; set; }
    }
}
