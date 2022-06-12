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

namespace Wardakstudio.Services.ProductsAPI.UnitTests.Producers.Queries
{
    public class GetProducerListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProducerRepository> _mockRepo;

        public GetProducerListRequestHandlerTests()
        {
            _mockRepo = MockProducerRepository.GetProducerRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task If_we_send_a_query_for_the_number_of_records_in_the_company_table_Returns_list_of_ProducerDto_and_count_three()
        {
            var handler = new GetProducersListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetProducersListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<ProducerDto>>();

            result.Count.ShouldBe(3);
        }
    }
}
