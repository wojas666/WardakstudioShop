using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecification;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductSpecifications.Requests.Queries
{
    public class GetProductSpecyficationRequest : IRequest<ProductSpecificationDto>
    {
        public int ProductSpecificationId { get; set; }
    }
}
