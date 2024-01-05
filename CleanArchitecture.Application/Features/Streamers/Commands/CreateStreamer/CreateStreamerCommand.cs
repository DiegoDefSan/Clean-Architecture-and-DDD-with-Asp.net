using MediatR;

namespace CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommand : IRequest<int> // Devuelve el valor int que es del id
    {
        public string Nombre { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
