using MediatR;
using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Features.ProductSpecifications.Requests.Queries;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecification;
using Wardakstudio.Services.ProductsAPI.Repository;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductSpecifications.Handles.Queries
{
    public class GetProductSpecificationsListRequestHandler : IRequestHandler<GetProductSpecificationsListRequest, List<ProductSpecificationDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductSpecificationRepository _repository;

        public GetProductSpecificationsListRequestHandler(IMapper mapper, IProductSpecificationRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<ProductSpecificationDto>> Handle(GetProductSpecificationsListRequest request, CancellationToken cancellationToken)
        {
            var productSpecifications = await _repository.GetProductSpecificationsList(request.ProductId);

            return _mapper.Map<List<ProductSpecificationDto>>(productSpecifications);
        }
    }
}
