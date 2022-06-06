using AutoMapper;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Features.ProductSpecificationDetails.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Repository;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductSpecificationDetails.Handles.Commands
{
    public class CreateProductSpecificationDetailRequestHandler : IRequestHandler<CreateProductSpecificationDetailRequest, int>
    {
        private readonly IMapper _mapper;
        private readonly IProductSpecificationDetailRepository _repository;

        public CreateProductSpecificationDetailRequestHandler(IMapper mapper, IProductSpecificationDetailRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Handle(CreateProductSpecificationDetailRequest request, CancellationToken cancellation)
        {
            var newProductSpecificationDetail = _mapper.Map<ProductSpecificationDetail>(request.ProductSpecificationDetailDto);
            newProductSpecificationDetail = await _repository.Add(newProductSpecificationDetail);

            return newProductSpecificationDetail.Id;
        }
    }
}
