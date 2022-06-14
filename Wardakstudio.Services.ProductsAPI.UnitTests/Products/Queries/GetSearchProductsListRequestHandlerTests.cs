using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardakstudio.Services.ProductsAPI.Exceptions;
using Wardakstudio.Services.ProductsAPI.Features.Products.Handlers.Queries;
using Wardakstudio.Services.ProductsAPI.Features.Products.Requests.Queries;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Product;
using Wardakstudio.Services.ProductsAPI.Profiles;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;
using Wardakstudio.Services.ProductsAPI.UnitTests.Mocks;

namespace Wardakstudio.Services.ProductsAPI.UnitTests.Products.Queries
{
    public class GetSearchProductsListRequestHandlerTests
    {
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly Mock<IProducerRepository> _mockProducerRepository;
        private readonly Mock<IProductCategoryRepository> _mockProductCategoryRepository;

        private readonly SearchProductDto _validSearchProductDto;
        private readonly SearchProductDto _validSearchProductDtoWithoutNameAndProducerIds;
        private readonly SearchProductDto _validSearchProductDtoWithSortByHighestPrice;
        private readonly SearchProductDto _validSearchProductDtoWithSetMinAndMaxPrice;


        private readonly SearchProductDto _notValidSearchProductDto_MinMaxPrice;
        private readonly SearchProductDto _notValidSearchProductDto_ProducerNotExist;


        private readonly IMapper _mapper;

        public GetSearchProductsListRequestHandlerTests()
        {
            _mockProductRepository = MockIProductRepository.GetProductRepository();
            _mockProducerRepository = MockIProducerRepository.GetProducerRepository();
            _mockProductCategoryRepository = MockIProductCategoryRepository.GetMockProdoctCategoryRepository();

            _validSearchProductDto = new SearchProductDto()
            {
                MinPrice = 0,
                MaxPrice = 10,
                Name = "test",
                IsAvailable = true,
                ProducerIds = new List<int> { 1, 2 },
                ProductCategoryIds = new List<int> { 1 },
                SortType = SortType.HighPrice
            };

            _validSearchProductDtoWithoutNameAndProducerIds = new SearchProductDto()
            {
                MinPrice = 0,
                MaxPrice = 10,
                IsAvailable = true,
                ProductCategoryIds = new List<int> { 1 },
                SortType = SortType.HighPrice
            };

            _notValidSearchProductDto_MinMaxPrice = new SearchProductDto()
            {
                MinPrice = 10,
                MaxPrice = 0,
            };

            _notValidSearchProductDto_ProducerNotExist = new SearchProductDto()
            {
                ProducerIds = new List<int> { 1, int.MaxValue, 3 },
            };

            _validSearchProductDtoWithSortByHighestPrice = new SearchProductDto()
            {
                SortType = SortType.HighPrice
            };

            _validSearchProductDtoWithSetMinAndMaxPrice = new SearchProductDto()
            {
                MinPrice = 15,
                MaxPrice = 70
            };

            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task If_SearchProductDto_is_valid_Should_run_getsearchproductlist_method_in_productrepository()
        {
            var handler = new GetSearchProductsListRequestHandler(_mapper,
                _mockProductRepository.Object,
                _mockProducerRepository.Object,
                _mockProductCategoryRepository.Object);

            await handler.Handle(new GetSearchProductsListRequest() { SearchProduct = _validSearchProductDto }, CancellationToken.None);

            _mockProductRepository.Verify(x => x.GetSearchProductsList(It.IsAny<SearchProductDto>()), Times.Once);
        }

        [Fact]
        public async Task If_SearchProductDto_is_valid_Should_run_exists_method_in_producerrepository_and_productcategoryrepository()
        {
            var handler = new GetSearchProductsListRequestHandler(_mapper,
                _mockProductRepository.Object,
                _mockProducerRepository.Object,
                _mockProductCategoryRepository.Object);

            await handler.Handle(new GetSearchProductsListRequest { SearchProduct = _validSearchProductDto }, CancellationToken.None);

            _mockProducerRepository.Verify(x => x.Exists(It.IsAny<int>()), Times.Exactly(2));
            _mockProductCategoryRepository.Verify(x => x.Exists(It.IsAny<int>()), Times.Exactly(1));
        }

        [Fact]
        public async Task If_SearchProductDto_is_valid_without_name_and_producer_ids_Should_not_run_exists_in_producerrepository_and_run_getsearchproductlist_in_productrepository()
        {
            var handler = new GetSearchProductsListRequestHandler(_mapper,
                _mockProductRepository.Object,
                _mockProducerRepository.Object,
                _mockProductCategoryRepository.Object);

            await handler.Handle(new GetSearchProductsListRequest { SearchProduct = _validSearchProductDtoWithoutNameAndProducerIds }, CancellationToken.None);

            _mockProducerRepository.Verify(x => x.Exists(It.IsAny<int>()), Times.Never);
            _mockProductRepository.Verify(x => x.GetSearchProductsList(It.IsAny<SearchProductDto>()), Times.Once);
        }

        [Fact]
        public async Task If_SearchProductDto_min_max_price_is_not_valid_Should_throw_validation_exception()
        {
            var handler = new GetSearchProductsListRequestHandler(_mapper,
                _mockProductRepository.Object,
                _mockProducerRepository.Object,
                _mockProductCategoryRepository.Object);

            await Should.ThrowAsync<ValidationException>(async () =>
            {
                await handler.Handle(new GetSearchProductsListRequest { SearchProduct = _notValidSearchProductDto_MinMaxPrice }, CancellationToken.None);
            });
        }

        [Fact]
        public async Task If_SearchProductDto_producers_ids_not_exists_in_producerrepository_Should_throw_validation_exception()
        {
            var handler = new GetSearchProductsListRequestHandler(_mapper,
                _mockProductRepository.Object,
                _mockProducerRepository.Object,
                _mockProductCategoryRepository.Object);

            await Should.ThrowAsync<ValidationException>(async () =>
            {
                await handler.Handle(new GetSearchProductsListRequest { SearchProduct = _notValidSearchProductDto_ProducerNotExist }, CancellationToken.None);
            });
        }

        [Fact]
        public async Task If_SearchProductDto_is_valid_without_name_and_producer_ids_Returns_productdto_list_with_one_element()
        {
            var handler = new GetSearchProductsListRequestHandler(_mapper,
                _mockProductRepository.Object,
                _mockProducerRepository.Object,
                _mockProductCategoryRepository.Object);

            var result = await handler.Handle(new GetSearchProductsListRequest() { SearchProduct = _validSearchProductDtoWithoutNameAndProducerIds }, CancellationToken.None);

            result.ShouldBeOfType<List<ProductDto>>();
            result.Count.ShouldBe(1);
        }

        [Fact]
        public async Task If_searchproductdto_is_valid_with_sorting_by_high_price_Return_productdto_list_with_three_elements_and_sorted_by_price()
        {
            var handler = new GetSearchProductsListRequestHandler(_mapper,
                _mockProductRepository.Object,
                _mockProducerRepository.Object,
                _mockProductCategoryRepository.Object);

            var result = await handler.Handle(new GetSearchProductsListRequest() { SearchProduct = _validSearchProductDtoWithSortByHighestPrice }, CancellationToken.None);

            result.ShouldBeOfType<List<ProductDto>>();
            result.Count.ShouldBe(3);

            result.Select(x=>x.Price).ShouldBeInOrder(SortDirection.Descending);
        }

        [Fact]
        public async Task If_searchproductdto_is_valid_with_min_and_max_price_Return_productdto_list_with_two_elements()
        {
            var handler = new GetSearchProductsListRequestHandler(_mapper,
                _mockProductRepository.Object,
                _mockProducerRepository.Object,
                _mockProductCategoryRepository.Object);

            var result = await handler.Handle(new GetSearchProductsListRequest() { SearchProduct = _validSearchProductDtoWithSetMinAndMaxPrice }, CancellationToken.None);

            result.ShouldBeOfType<List<ProductDto>>();

            foreach(var item in result)
            {
                item.Price.ShouldBeGreaterThan(_validSearchProductDtoWithSetMinAndMaxPrice.MinPrice ?? 0);
                item.Price.ShouldBeLessThan(_validSearchProductDtoWithSetMinAndMaxPrice.MaxPrice ?? 0);
            }

        }
    }
}
