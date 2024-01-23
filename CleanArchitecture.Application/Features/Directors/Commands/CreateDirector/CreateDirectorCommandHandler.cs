using AutoMapper;
using CleanArchitecture.Application.Constracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Directors.Commands.CreateDirector
{
    public class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommand, int>
    {
        private readonly ILogger<CreateDirectorCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDirectorCommandHandler(ILogger<CreateDirectorCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
        {
            var directorEntity = _mapper.Map<Director>(request);

            // En vez de llamar al repositorio específico de director, llamamos a la interfaz
            // genérica
            _unitOfWork.Repository<Director>().AddEntity(directorEntity); // Se agrega la entidad a la memoria

            var result = await _unitOfWork.Complete(); // Se termina la transacción agregando la entidad a la db
        
            if (result<=0)
            {
                _logger.LogError("No se insertó el record del director");
                throw new Exception("No se pudo insertar el record del director.");
            }

            return directorEntity.Id;
        }
    }
}
