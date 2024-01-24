using AutoMapper;
using CleanArchitecture.Application.Constracts.Infrastructure;
using CleanArchitecture.Application.Constracts.Persistence;
using CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer;
using CleanArchitecture.Application.Mapping;
using CleanArchitecture.Application.UnitTests.Mocks;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Features.Streamers.Commands.CreateSreamer
{
    public class CreateStreamerCommandHandlerXUnitTests
    {

        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<IEmalService> _emalService;
        private readonly Mock<ILogger<CreateStreamerCommandHandler>> _logger;

        public CreateStreamerCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var _mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = _mapperConfig.CreateMapper();

            _emalService = new Mock<IEmalService>();

            _logger = new Mock<ILogger<CreateStreamerCommandHandler>>();

            MockStreamerRepository.AddDataStreamerRepository(_unitOfWork.Object.StreamerDbContext);
        }

        [Fact]
        public async Task CreateStreamerCommand_InputStreamer_ReturnsNumber()
        {
            // Arrange
            var createStreamerRequest = new CreateStreamerCommand
            {
                Nombre = "Diego Streaming",
                Url = "https://www.diegostreaming.com"
            };
            var handler = new CreateStreamerCommandHandler(
                    _unitOfWork.Object, _mapper, _emalService.Object, _logger.Object
                );

            // Act
            var result = await handler.Handle(createStreamerRequest, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<int>();
        }

    }
}
