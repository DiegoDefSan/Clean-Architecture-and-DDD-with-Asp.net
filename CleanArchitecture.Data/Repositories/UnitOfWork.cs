using CleanArchitecture.Application.Constracts.Persistence;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Infrastructure.Persistence;
using System.Collections;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        // Coleccion de referencias a los servicios repositorios
        private Hashtable _repositories;
        private readonly StreamerDbContext _context;

        private IVideoRepository _videoRepository;
        private IStreamerRepository _streamerRepository;

        // Inyecciion via propiedades
        // ??= no puede ser null, se crea una instancia
        public IVideoRepository VideoRepository => _videoRepository ??= new VideoRepository(_context);
        public IStreamerRepository StreamerRepository => _streamerRepository ??= new StreamerRepository(_context);

        public UnitOfWork(StreamerDbContext context)
        {
            _context = context;
        }

        // Dispara la confirmación de todas las transacciones
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        // Eliminar context cuando la transacción halla culminado
        public void Dispose()
        {
            _context.Dispose();
        }

        // Instancia del repositorio
        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(
                    repositoryType.MakeGenericType(typeof(TEntity)), _context
                );
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }
    }
}
