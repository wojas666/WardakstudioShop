using AutoMapper;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Features.ProductSpecificationDetails.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductSpecificationDetails.Handles.Commands
{
    public class CreateProductSpecificationDetailCommandHandler : IRequestHandler<CreateProductSpecificationDetailCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IProductSpecificationDetailRepository _repository;

        public CreateProductSpecificationDetailCommandHandler(IMapper mapper, IProductSpecificationDetailRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Handle(CreateProductSpecificationDetailCommand request, CancellationToken cancellation)
        {
            var newProductSpecificationDetail = _mapper.Map<ProductSpecificationDetail>(request.ProductSpecificationDetailDto);
            newProductSpecificationDetail = await _repository.Add(newProductSpecificationDetail);

            return newProductSpecificationDetail.Id;
        }
    }
}
