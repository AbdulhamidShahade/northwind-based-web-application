using FullWebProjectWithAPI.Web.Services.Base;
using NorthwindBasedWebApplication.Models;
using NorthwindBasedWebApplication.Services.IService;

namespace NorthwindBasedWebApplication.Services.SpecialService
{
    public class AuthSpecialService : BaseService
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthSpecialService(IAuthorizationService authorizationService, IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _authorizationService = authorizationService;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<UserRolesResponse> GetRolesByIdAsync(int id)
        {
            return _authorizationService.GetRolesById<UserRolesResponse>(id).GetAwaiter().GetResult();
        }

        public async Task<UserRolesResponse> GetRolesByEmailAsync(string email)
        {
            return _authorizationService.GetRolesByEmail<UserRolesResponse>(email).GetAwaiter().GetResult();  
        }

        public async Task<List<string>> GetRolesNamesByEmailAsync(string email)
        {
            return _authorizationService.GetRolesNamesByEmail<List<string>>(email).GetAwaiter().GetResult();
        }
    }
}
