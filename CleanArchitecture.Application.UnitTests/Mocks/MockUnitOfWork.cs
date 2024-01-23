using CleanArchitecture.Application.Constracts.Persistence;
using Moq;

namespace CleanArchitecture.Application.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockVideoRepository = MockVideoRepository.GetVideoRepository();

            mockUnitOfWork.Setup(r => r.VideoRepository).Returns(mockVideoRepository.Object);

            return mockUnitOfWork;
        }
    }
}
