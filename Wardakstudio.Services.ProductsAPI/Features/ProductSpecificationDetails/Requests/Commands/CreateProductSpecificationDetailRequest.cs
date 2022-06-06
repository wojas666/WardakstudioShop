using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecificationDetail;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductSpecificationDetails.Requests.Commands
{
    public class CreateProductSpecificationDetailRequest : IRequest<int>
    {
        public CreateProductSpecificationDetailDto ProductSpecificationDetailDto { get; set; }
    }
}
