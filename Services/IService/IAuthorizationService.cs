using NorthwindBasedWebApplication.Models;

namespace NorthwindBasedWebApplication.Services.IService
{
    public interface IAuthorizationService
    {
        Task<T> GetRolesById<T>(int id);
        Task<T> GetRolesByEmail<T>(string email);
        Task<T> GetRolesNamesByEmail<T>(string email);
    }
}
