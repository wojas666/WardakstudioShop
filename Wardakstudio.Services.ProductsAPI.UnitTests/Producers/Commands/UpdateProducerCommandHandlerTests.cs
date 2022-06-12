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
using Wardakstudio.Services.ProductsAPI.Profiles;
using Wardakstudio.Services.ProductsAPI.Repository.Contracts;
using Wardakstudio.Services.ProductsAPI.UnitTests.Mocks;
using Shouldly;
using Wardakstudio.Services.ProductsAPI.Exceptions;

namespace Wardakstudio.Services.ProductsAPI.UnitTests.Producers.Commands
{
    public class UpdateProducerCommandHandlerTests
    {
        private readonly Mock<IProducerRepository> _mockRepository;
        private readonly IMapper _mapper;

        private readonly UpdateProducerDto _validUpdateProducerDtoToUpdate;
        private readonly UpdateProducerDto _notValidNameAndDescriptionUpdateProducerDtoToUpdate;
        private readonly UpdateProducerDto _notExistUpdateProducerDtoInRepository;

        public UpdateProducerCommandHandlerTests()
        {
            _mockRepository = MockProducerRepository.GetProducerRepository();

            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
            });

            _validUpdateProducerDtoToUpdate = new UpdateProducerDto()
            {
                Id = 2,
                Name = "Adidaś",
                Description = "Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma."
            };

            _notValidNameAndDescriptionUpdateProducerDtoToUpdate = new UpdateProducerDto()
            {
                Id = 2,
                Name = String.Empty,
                Description = String.Empty
            };

            _notExistUpdateProducerDtoInRepository = new UpdateProducerDto()
            {
                Id = -1,
                Name = "Adidaś",
                Description = "Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma.Jakaś testowa firma."
            };



            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task If_UpdateProducerDto_is_valid_Should_run_update_method_in_producer_repository()
        {
            var handler = new UpdateProducerCommandHandler(_mapper, _mockRepository.Object);
            await handler.Handle(new UpdateProducerCommand() { ProducerToUpdate = _validUpdateProducerDtoToUpdate }, CancellationToken.None);

            _mockRepository.Verify(x=>x.Update(It.IsAny<Producer>()), Times.Once);
        }

        [Fact]
        public async Task If_UpdateProducerDto_is_no_valid_Should_throw_validationexception()
        {
            var handler = new UpdateProducerCommandHandler(_mapper, _mockRepository.Object);
            await Should.ThrowAsync<ValidationException>(async () => await handler.Handle(
                new UpdateProducerCommand() { ProducerToUpdate = _notValidNameAndDescriptionUpdateProducerDtoToUpdate }, 
                CancellationToken.None));
        }

        [Fact]
        public async Task If_UpdateProducerDto_id_is_not_exists_in_producer_repository_Should_throw_validationexception()
        {
            var handler = new UpdateProducerCommandHandler(_mapper, _mockRepository.Object);
            await Should.ThrowAsync<ValidationException>(async () => await handler.Handle(
                new UpdateProducerCommand() { ProducerToUpdate = _notExistUpdateProducerDtoInRepository }, 
                CancellationToken.None));
        }

    }
}
