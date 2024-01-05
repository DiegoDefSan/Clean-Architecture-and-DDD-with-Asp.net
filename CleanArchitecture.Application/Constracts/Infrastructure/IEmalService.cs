using CleanArchitecture.Application.Models;

namespace CleanArchitecture.Application.Constracts.Infrastructure
{
    public interface IEmalService
    {
        Task<bool> SendEmail(Email email);
    }
}
