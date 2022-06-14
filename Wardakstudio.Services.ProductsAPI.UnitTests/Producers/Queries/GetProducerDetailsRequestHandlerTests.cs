using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardakstudio.Services.ProductsAPI.Features.Producers.Handlers.Queries;
using Wardakstudio.Services.ProductsAPI.Features.Producers.Requests.Queries;
using Wardakstudio.Services.ProductsAPI.Profiles;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;
using Wardakstudio.Services.ProductsAPI.UnitTests.Mocks;
using Shouldly;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer;
using Wardakstudio.Services.ProductsAPI.Exceptions;

namespace Wardakstudio.Services.ProductsAPI.UnitTests.Producers.Queries
{
    public class GetProducerDetailsRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProducerRepository> _repository;

        
        public GetProducerDetailsRequestHandlerTests()
        {
            _repository = MockIProducerRepository.GetProducerRepository();

            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task If_producer_id_is_equal_to_two_Returns_ProducerDto_object_where_id_is_equal_to_two()
        {
            var handler = new GetProducerDetailsRequestHandler(_mapper, _repository.Object);

            var result = await handler.Handle(new GetProducerDetailsRequest() { Id = 2 }, CancellationToken.None);

            result.ShouldBeOfType<ProducerDto>();

            result.Id.ShouldBe(2);
        }

        [Fact]
        public async Task If_a_producer_with_the_given_id_is_not_in_the_database_Returns_null()
        {
            var handler = new GetProducerDetailsRequestHandler(_mapper, _repository.Object);

            var result = await handler.Handle(new GetProducerDetailsRequest() { Id = 100 }, CancellationToken.None);

            result.ShouldBeNull<ProducerDto>();
        }
    }
}
