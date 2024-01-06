using CleanArchitecture.Domain;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class StreamerDbContextSeed
    {
        public static async Task SeedAsync(StreamerDbContext context, ILogger<StreamerDbContextSeed> logger)
        {
            if (!context.Streamers.Any())
            {
                context.Streamers.AddRange(GetPreconfiguredStreamer());
                await context.SaveChangesAsync();

                logger.LogInformation("Estamos insertando nuevos records al db {context}", typeof(StreamerDbContext).Name);
            }
        }

        private static IEnumerable<Streamer> GetPreconfiguredStreamer()
        {
            return new List<Streamer>
            {
                new Streamer
                {
                    CreatedBy = "Diego",
                    Nombre = "Maxi HBP",
                    Url = "http://www.hbp.com"
                },
                new Streamer
                {
                    CreatedBy = "Diego",
                    Nombre = "Amazon VIP",
                    Url = "http://www.amazonvip.com"
                }
            };
        }
    }
}
