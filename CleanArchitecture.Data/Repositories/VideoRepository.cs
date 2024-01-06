using CleanArchitecture.Application.Constracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class VideoRepository : RepositoryBase<Video>, IVideoRepository
    {
        public VideoRepository(StreamerDbContext context) : base(context)
        {
        }

        public async Task<Video> GetVideoByNombre(string nombreVideo)
        {
            var video = await _context.Videos!.Where(v => v.Nombre!.Equals(nombreVideo))
                                    .FirstOrDefaultAsync();

            return video;
        }

        public async Task<IEnumerable<Video>> GetVideosByUsername(string username)
        {
            var videos = await _context.Videos!.Where(v => v.CreatedBy.Equals(username))
                .ToListAsync();

            return videos;
        }
    }
}
