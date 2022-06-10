using MediatR;
using Wardakstudio.Services.ProductsAPI.Exceptions;
using Wardakstudio.Services.ProductsAPI.Features.ProductImages.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductImages.Handlers.Commands
{
    public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommand, Unit>
    {
        private readonly IProductImageRepository _repository;

        public DeleteProductImageCommandHandler(IProductImageRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductImageCommand request, CancellationToken cancellationToken)
        {
            var productImageToDelete = await _repository.GetById(request.Id);

            if (productImageToDelete == null)
                throw new NotFoundException(nameof(ProductImage), request.Id);

            await _repository.Delete(productImageToDelete);

            return Unit.Value;
        }
    }
}
