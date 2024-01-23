using AutoMapper;
using CleanArchitecture.Application.Constracts.Infrastructure;
using CleanArchitecture.Application.Constracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
    {
        // private readonly IStreamerRepository _streamerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmalService _emailService;
        private readonly ILogger<CreateStreamerCommandHandler> _logger;

        public CreateStreamerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmalService emailService, ILogger<CreateStreamerCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            // Recibo un StreamerCommand, pero la db me pide la entidad Streamer
            // Se debe hacer un mapeo hacia el tipo entidad
            var streamerEntity = _mapper.Map<Streamer>(request);

            // var newStreamer = await _streamerRepository.AddAsync(streamerEntity);
            _unitOfWork.StreamerRepository.AddEntity(streamerEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"No se pudo insertar el record de streamer");
            }
            
            _logger.LogInformation($"Streamer {streamerEntity.Id} fue creado exitosamente");

            await SendEmail(streamerEntity);

            return streamerEntity.Id;
        }

        private async Task SendEmail(Streamer streamer)
        {
            var email = new Email
            {
                To = "vaxi.drez.social@gmail.com",
                Body = "La compania de streame se creo correctamente",
                Subject = "Mensaje de alerta"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Errores enviando el email de {streamer.Id}");
            }
        }
    }
}
