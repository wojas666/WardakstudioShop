﻿using AutoMapper;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Features.ProductSpecifications.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Repository;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductSpecifications.Handles.Commands
{
    public class CreateProductSpecificationRequestHandler : IRequestHandler<CreateProductSpecificationRequest, int>
    {
        private readonly IMapper _mapper;
        private readonly IProductSpecificationRepository _repository;

        public CreateProductSpecificationRequestHandler(IMapper mapper, IProductSpecificationRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Handle(CreateProductSpecificationRequest request, CancellationToken cancellation)
        {
            var newProductSpecification = _mapper.Map<ProductSpecification>(request.ProductSpecificationDto);
            newProductSpecification = await _repository.Add(newProductSpecification);

            return newProductSpecification.Id;
        }
    }
}
