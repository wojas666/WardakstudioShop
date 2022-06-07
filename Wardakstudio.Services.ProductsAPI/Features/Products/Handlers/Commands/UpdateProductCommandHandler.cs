using MediatR;
using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Models.Dtos;
using Wardakstudio.Services.ProductsAPI.Repository;
using Wardakstudio.Services.ProductsAPI.Features.Products.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Models;

namespace Wardakstudio.Services.ProductsAPI.Features.Products.Handlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;

        public UpdateProductCommandHandler(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(request.ProductId);

            if (request.ProductToUpdate is not null)
            {
                product = _mapper.Map<Product>(request.ProductToUpdate);

                await _repository.Update(product);
            }
            else if(request.ChangeProductPublishedStatusDto is not null)
            {
                await _repository.ChangeProductPublishedStatus(product, request.ChangeProductPublishedStatusDto.IsPublished);
            }

            return Unit.Value;
        }
    }
}
