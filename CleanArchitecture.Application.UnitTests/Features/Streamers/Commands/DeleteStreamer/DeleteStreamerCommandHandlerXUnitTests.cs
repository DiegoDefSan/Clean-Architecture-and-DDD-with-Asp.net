using AutoMapper;
using CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer;
using CleanArchitecture.Application.Mapping;
using CleanArchitecture.Application.UnitTests.Mocks;
using CleanArchitecture.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;
using DeleteStreamerCommandHandler = CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer.DeleteStreamerCommandHandler;

namespace CleanArchitecture.Application.UnitTests.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<DeleteStreamerCommandHandler>> _logger;

        public DeleteStreamerCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var _mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = _mapperConfig.CreateMapper();


            _logger = new Mock<ILogger<DeleteStreamerCommandHandler>>();

            MockStreamerRepository.AddDataStreamerRepository(_unitOfWork.Object.StreamerDbContext);
        }

        [Fact]
        public async Task DeleteStreamerCommand_InputStreamerById_ReturnsUnit()
        {
            // Arrange
            var deleteStreamerRequest = new DeleteStreamerCommand
            {
                Id = 8001
            };
            var handler = new DeleteStreamerCommandHandler(
                    _unitOfWork.Object, _mapper, _logger.Object
                );

            // Act
            var result = await handler.Handle(deleteStreamerRequest, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<Unit>();
        }
    }
}
