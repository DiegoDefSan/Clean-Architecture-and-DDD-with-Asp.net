using AutoMapper;
using CleanArchitecture.Application.Constracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListQueryHandler : IRequestHandler<GetVideosListQuery, List<VideosVm>>
    {
        // private readonly IVideoRepository _videoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetVideosListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<VideosVm>> Handle(GetVideosListQuery request, CancellationToken cancellationToken)
        {
            // var videoList = await _videoRepository.GetVideosByUsername(request.Username);
            var videoList = await _unitOfWork.VideoRepository.GetVideosByUsername(request.Username);

            var videosVmList = _mapper.Map<List<VideosVm>>(videoList);

            return videosVmList;
        }
    }
}
