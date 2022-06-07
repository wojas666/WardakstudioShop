using MediatR;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecification;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductSpecifications.Requests.Commands
{
    public class CreateProductSpecificationCommand : IRequest<int>
    {
        public CreateProductSpecificationDto ProductSpecificationDto { get; set; }
    }
}
