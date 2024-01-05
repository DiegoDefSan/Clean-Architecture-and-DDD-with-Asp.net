using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        // Objetivo: analizar los métodos handler de los command y query
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex) 
            { 
                // Capturar el request q es enviado
                var requestName = typeof(TRequest).Name;

                _logger.LogError(ex, "Application request: Sucedio una excepción para el request {Name} {@Request}", requestName, request);

                throw;
            }
        }
    }
}
