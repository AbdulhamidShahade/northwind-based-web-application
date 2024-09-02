using NorthwindBasedWebApplication.Models.Dtos.AuthenticationDtos;

namespace NorthwindBasedWebApplication.Services.IService
{
    public interface IAuthenticationService
    {
        Task<T> Login<T>(LoginRequestDto loginRequestDto);
        Task<T> Register<T>(RegisterRequestDto registerRequestDto);
    }
}
