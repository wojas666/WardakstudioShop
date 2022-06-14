using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardakstudio.Services.ProductsAPI.Features.Products.Handlers.Queries;
using Wardakstudio.Services.ProductsAPI.Features.Products.Requests.Queries;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Profiles;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;
using Wardakstudio.Services.ProductsAPI.UnitTests.Mocks;
using Shouldly;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product;

namespace Wardakstudio.Services.ProductsAPI.UnitTests.Products.Queries
{
    public class GetProductListRequestHandlerTests
    {
        private readonly Mock<IProductRepository> _mockRepository;
        private readonly IMapper _mapper;

        public GetProductListRequestHandlerTests()
        {
            _mockRepository = MockIProductRepository.GetProductRepository();

            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task If_we_ask_for_all_records_in_the_product_table_Returns_list_of_ProductDto_and_count_three()
        {
            var handler = new GetProductsListRequestHandler(_mapper, _mockRepository.Object);
            var result = await handler.Handle(new GetProductsListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<ProductDto>>();
            result.Count.ShouldBe(3);
        }
    }
}
