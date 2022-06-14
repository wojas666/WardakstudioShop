using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardakstudio.Services.ProductsAPI.Features.Products.Handlers.Queries;
using Wardakstudio.Services.ProductsAPI.Features.Products.Requests.Queries;
using Wardakstudio.Services.ProductsAPI.Profiles;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;
using Wardakstudio.Services.ProductsAPI.UnitTests.Mocks;
using Shouldly;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product;
using Wardakstudio.Services.ProductsAPI.Exceptions;

namespace Wardakstudio.Services.ProductsAPI.UnitTests.Products.Queries
{
    public class GetProductDetailsRequestHandlerTests
    {
        private readonly Mock<IProductRepository> _mockRepository;
        private readonly IMapper _mapper;

        public GetProductDetailsRequestHandlerTests()
        {
            _mockRepository = MockIProductRepository.GetProductRepository();

            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task If_we_ask_for_record_details_by_exist_productid_Returns_ProductDto_not_null_object__id_one()
        {
            var handler = new GetProductDetailsRequestHandler(_mapper, _mockRepository.Object);
            var result = await handler.Handle(new GetProductDetailsRequest() { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<ProductDto>();
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task If_we_ask_for_record_details_by_not_exist_producerid_Throws_not_found_exception()
        {
            var handler = new GetProductDetailsRequestHandler(_mapper, _mockRepository.Object);
            await Should.ThrowAsync<NotFoundException>(async () => await handler.Handle(new GetProductDetailsRequest() { Id = int.MaxValue }, CancellationToken.None));
        }
    }
}
