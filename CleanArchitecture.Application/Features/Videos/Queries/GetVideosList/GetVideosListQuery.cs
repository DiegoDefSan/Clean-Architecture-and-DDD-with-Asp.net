using MediatR;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListQuery : IRequest<List<VideosVm>> // Vm = view model
    {
        public string Username { get; set; } = String.Empty;

        public GetVideosListQuery(string username) {
            Username = username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
