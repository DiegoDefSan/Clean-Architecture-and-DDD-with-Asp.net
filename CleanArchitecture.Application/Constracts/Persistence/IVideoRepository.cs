using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Constracts.Persistence
{
    public interface IVideoRepository : IAsyncRepository<Video>
    {
        Task<Video> GetVideoByNombre(string nombreVideo);
        Task<IEnumerable<Video>> GetVideosByUsername(string username);
    }
}
