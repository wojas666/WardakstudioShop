using AutoMapper;
using MediatR;
using Wardakstudio.Services.ProductsAPI.Features.ProductImages.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Repository;

namespace Wardakstudio.Services.ProductsAPI.Features.ProductImages.Handlers.Commands
{
    public class UpdateProductImageCommandHandler : IRequestHandler<UpdateProductImageCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductImageRepository _repository;

        public UpdateProductImageCommandHandler(IMapper mapper, IProductImageRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductImageCommand request, CancellationToken cancellationToken)
        {
            var productImage = await _repository.GetById(request.ProductImageId);

            if(request.ImageToUpdate != null)
            {
                productImage = _mapper.Map<ProductImage>(request.ImageToUpdate);

                await _repository.Update(productImage);
            }
            else if(request.ChangeProductPublishedStatusDto != null)
            {
                await _repository.ChangeProductImagePublishedStatus(productImage, request.ChangeProductPublishedStatusDto.IsPublished);
            }

            return Unit.Value;
        }
    }
}
