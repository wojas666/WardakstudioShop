using MediatR;
using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Features.Products.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Exceptions;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Features.Products.Handlers.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;

        public DeleteProductCommandHandler(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductCommand command, CancellationToken cancellation)
        {
            var productToDelete = await _repository.GetById(command.Id);

            if (productToDelete == null)
                throw new NotFoundException(nameof(Product), command.Id);

            await _repository.Delete(productToDelete);

            return Unit.Value;
        }
    }
}
