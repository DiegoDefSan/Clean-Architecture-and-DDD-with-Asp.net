using AutoMapper;
using CleanArchitecture.Application.Constracts.Infrastructure;
using CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer;
using CleanArchitecture.Application.Mapping;
using CleanArchitecture.Application.UnitTests.Mocks;
using CleanArchitecture.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<IEmalService> _emalService;
        private readonly Mock<ILogger<DeleteStreamerCommandHandler>> _logger;

        public UpdateStreamerCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var _mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = _mapperConfig.CreateMapper();

            _emalService = new Mock<IEmalService>();

            _logger = new Mock<ILogger<DeleteStreamerCommandHandler>>();

            MockStreamerRepository.AddDataStreamerRepository(_unitOfWork.Object.StreamerDbContext);
        }

        [Fact]
        public async Task UpdateStreamerCommand_InputStreamer_ReturnsUnit()
        {
            // Arrange
            var updateStreamerRequest = new UpdateStreamerCommand
            {
                Id = 8001,
                Nombre = "Diego Streaming Max",
                Url = "https://www.diegostreamingmax.com"
            };
            var handler = new DeleteStreamerCommandHandler(
                    _unitOfWork.Object, _mapper, _emalService.Object, _logger.Object
                );

            // Act
            var result = await handler.Handle(updateStreamerRequest, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<Unit>();
        }
    }
}
