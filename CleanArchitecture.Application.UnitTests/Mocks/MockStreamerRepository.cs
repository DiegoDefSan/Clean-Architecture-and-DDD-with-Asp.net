using AutoFixture;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Application.UnitTests.Mocks
{
    public static class MockStreamerRepository
    {
        public static void AddDataStreamerRepository(StreamerDbContext streamerDbContextFake)
        {
            // Fixture genera la data aleatoria
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior()); // Evitar comportamiento de referencia circular
            var streamers = fixture.CreateMany<Streamer>().ToList();

            streamers.Add(fixture.Build<Streamer>()
                .With(tr => tr.Id, 8001)
                .Without(tr => tr.Videos) // No generar data en videos, para evitar errores en el delete
                .Create()
            );

            // Crear la instancia del Entity Framework
            streamerDbContextFake.Streamers!.AddRange(streamers);
            streamerDbContextFake.SaveChanges();
        }
    }
}
