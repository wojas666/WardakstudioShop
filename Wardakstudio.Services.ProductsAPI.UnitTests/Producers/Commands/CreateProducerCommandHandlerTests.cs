using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardakstudio.Services.ProductsAPI.Features.Producers.Handlers.Commands;
using Wardakstudio.Services.ProductsAPI.Features.Producers.Requests.Commands;
using Wardakstudio.Services.ProductsAPI.Models;
using Wardakstudio.Services.ProductsAPI.Models.Dtos.Producer;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;
using Wardakstudio.Services.ProductsAPI.UnitTests.Mocks;
using Shouldly;
using Wardakstudio.Services.ProductsAPI.Responses;
using Wardakstudio.Services.ProductsAPI.Profiles;

namespace Wardakstudio.Services.ProductsAPI.UnitTests.Producers.Commands
{
    public class CreateProducerCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProducerRepository> _mockRepository;

        private readonly CreateProducerDto _validProducerDtoForAdd = new CreateProducerDto() { Name = "Pepśi", Description = "Jakaś testowa firma do dodania.Jakaś testowa firma do dodania.Jakaś testowa firma do dodania.Jakaś testowa firma do dodania." };
        private readonly CreateProducerDto _notValidProducerDtoWithShorterDescForAdd = new CreateProducerDto() { Name = "Pepśi", Description = "Jakaś testowa firma do dodania." };
        private readonly CreateProducerDto _notValidProducerDtoWithLongerNameForAdd = new CreateProducerDto() { Name = "Pepśi Pepśi Pepśi Pepśi Pepśi Pepśi Pepśi Pepśi Pepśi Pepśi Pepśi Pepśi Pepśi Pepśi Pepśi Pepśi Pepśi Pepśi Pepśi Pepśi", Description = "Jakaś testowa firma do dodania.Jakaś testowa firma do dodania.Jakaś testowa firma do dodania.Jakaś testowa firma do dodania." };


        public CreateProducerCommandHandlerTests()
        {
            _mockRepository = MockProducerRepository.GetProducerRepository();

            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfiguration.CreateMapper();
        }

        [Fact]
        public async Task If_CreateProducerDto_is_valid_Return_BaseCommandResponse_object_with_issucces_value_equal_to_true_and_count_equal_four()
        {
            var handler = new CreateProducerCommandHandler(_mockRepository.Object, _mapper);
            var result = await handler.Handle(new CreateProducerCommand() { ProducerDto = _validProducerDtoForAdd }, CancellationToken.None);
            var allProducers = await _mockRepository.Object.GetAll();
            
            allProducers.Count.ShouldBe(4);
            result.ShouldBeOfType<BaseCommandResponse>();
        }

        [Fact]
        public async Task If_CreateProducerDto_is_not_valid_shorted_description_Returns_BaseCommandResponse_with_errors_and_issucces_false()
        {
            var handler = new CreateProducerCommandHandler(_mockRepository.Object, _mapper);
            var result = await handler.Handle(new CreateProducerCommand() { ProducerDto = _notValidProducerDtoWithShorterDescForAdd }, CancellationToken.None);
            var allProducers = await _mockRepository.Object.GetAll();

            allProducers.Count.ShouldBe(3);
            result.ShouldBeOfType<BaseCommandResponse>();
            result.IsSuccess.ShouldBe(false);
            result.Errors.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task If_CreateProducerDto_is_not_valid_longer_name_Returns_BaseCommandResponse_with_errors_and_issucces_false()
        {
            var handler = new CreateProducerCommandHandler(_mockRepository.Object, _mapper);
            var result = await handler.Handle(new CreateProducerCommand() { ProducerDto = _notValidProducerDtoWithLongerNameForAdd}, CancellationToken.None);
            var allProducers = await _mockRepository.Object.GetAll();

            allProducers.Count.ShouldBe(3);
            result.ShouldBeOfType<BaseCommandResponse>();
            result.IsSuccess.ShouldBe(false);
            result.Errors.Count.ShouldBeGreaterThan(0);
        }
    }
}
