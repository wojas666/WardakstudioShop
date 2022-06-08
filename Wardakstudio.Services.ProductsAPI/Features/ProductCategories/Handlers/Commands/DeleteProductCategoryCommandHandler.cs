using AutoMapper;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Exceptions;
using Wardakstudio.Services.ProductsAPI.Features.ProductCategories.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductCategories.Handlers.Commands
{
    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductCategoryRepository _repository;

        public DeleteProductCategoryCommandHandler(IMapper mapper, IProductCategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategoryToDelete = await _repository.GetById(request.ProductCategoryId);

            if (productCategoryToDelete == null)
                throw new NotFoundException(nameof(ProductCategories), request.ProductCategoryId);

            await _repository.Delete(productCategoryToDelete);

            return Unit.Value;
        }
    }
}
