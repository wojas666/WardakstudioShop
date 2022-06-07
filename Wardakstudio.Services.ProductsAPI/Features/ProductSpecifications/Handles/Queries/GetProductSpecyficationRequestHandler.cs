using MediatR;
using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Features.ProductSpecificationDetails.Requests;
using Wardakstudio.Services.ProductsAPI.Models.Dtos;
using Wardakstudio.Services.ProductsAPI.Features.ProductSpecifications.Requests.Queries;
using Wardakstudio.Services.ProductsAPI.Repository;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.ProductSpecification;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductSpecifications.Handles.Queries
{
    public class GetProductSpecyficationRequestHandler : IRequestHandler<GetProductSpecyficationRequest,ProductSpecificationDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductSpecificationRepository _repository;

        public GetProductSpecyficationRequestHandler(IMapper mapper, IProductSpecificationRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ProductSpecificationDto> Handle(GetProductSpecyficationRequest request, CancellationToken cancellation)
        {
            var productSpecification = await _repository.GetById(request.ProductSpecificationId);

            return _mapper.Map<ProductSpecificationDto>(productSpecification);
        }
    }
}
