using Services.Responses;

namespace Service.ServicesAbstractions
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(string username, string password);
    }
}
