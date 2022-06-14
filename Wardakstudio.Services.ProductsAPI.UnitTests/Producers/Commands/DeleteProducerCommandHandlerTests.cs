using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardakstudio.Services.ProductsAPI.Exceptions;
using Wardakstudio.Services.ProductsAPI.Features.Producers.Handlers.Commands;
using Wardakstudio.Services.ProductsAPI.Features.Producers.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Profiles;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;
using Wardakstudio.Services.ProductsAPI.UnitTests.Mocks;

namespace Wardakstudio.Services.ProductsAPI.UnitTests.Producers.Commands
{
    public class DeleteProducerCommandHandlerTests
    {
        private readonly Mock<IProducerRepository> _mockRepository;
        private readonly IMapper _mapper;

        public DeleteProducerCommandHandlerTests()
        {
            _mockRepository = MockIProducerRepository.GetProducerRepository();

            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async Task If_producerid_exist_in_producer_repository_Shuld_run_delete_method_in_repository()
        {
            var handler = new DeleteProducerCommandHandler(_mockRepository.Object, _mapper);
            await handler.Handle(new DeleteProducerCommand() { ProducerId = 1 }, CancellationToken.None);

            _mockRepository.Verify(x => x.Delete(It.IsAny<Producer>()), Times.Once);
        }

        [Fact]
        public async Task If_producerid_not_exist_in_producer_repository_Should_return_notfounexception()
        {
            var handler = new DeleteProducerCommandHandler(_mockRepository.Object, _mapper);
            await Should.ThrowAsync<NotFoundException>(async () => await handler.Handle(new DeleteProducerCommand() { ProducerId = Int32.MaxValue }, CancellationToken.None));
        }
    }
}
