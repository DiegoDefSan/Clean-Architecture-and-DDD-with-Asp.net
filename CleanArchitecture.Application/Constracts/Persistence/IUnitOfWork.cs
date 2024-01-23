using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Application.Constracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {

        IStreamerRepository StreamerRepository { get; }
        IVideoRepository VideoRepository { get; }

        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

        Task<int> Complete();
    }
}
