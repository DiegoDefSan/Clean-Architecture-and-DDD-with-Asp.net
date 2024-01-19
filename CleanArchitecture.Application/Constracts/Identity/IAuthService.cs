using CleanArchitecture.Application.Models.Identity;

namespace CleanArchitecture.Application.Constracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);

        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
