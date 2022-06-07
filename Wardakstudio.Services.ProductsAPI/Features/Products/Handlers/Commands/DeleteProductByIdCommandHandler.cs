using MediatR;
using AutoMapper;
using Wardakstudio.Services.ProductsAPI.Features.Products.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Repository;

namespace Wardakstudio.Services.ProductsAPI.Features.Products.Handlers.Commands
{
    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;

        public DeleteProductByIdCommandHandler(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductByIdCommand command, CancellationToken cancellation)
        {
            await _repository.DeleteById(command.Id);

            return Unit.Value;
        }
    }
}
