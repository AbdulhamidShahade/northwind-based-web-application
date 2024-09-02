using FullWebProjectWithAPI.Web.Services.Base;
using Microsoft.AspNetCore.Authorization;
using NorthwindBasedWebApplication.Models;

namespace NorthwindBasedWebApplication.Services.Service
{
    public class AuthorizationService : BaseService, NorthwindBasedWebApplication.Services.IService.IAuthorizationService 
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _url;

        public AuthorizationService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _url = configuration.GetValue<string>("ApiUrls:Base");
        }

        public async Task<T> GetRolesById<T>(int id)
        {
            return await SendAsync<T>(new ApiRequest
            {
                Token = "",
                ApiType = Models.Enums.ApiType.GET,
                Data = null,
                ApiUrl = $"{_url}/User/{id}/Roles"
            });
        }

        public async Task<T> GetRolesByEmail<T>(string email)
        {
            return await SendAsync<T>(new ApiRequest
            {
                ApiType = Models.Enums.ApiType.GET,
                Data = null,
                Token = string.Empty,
                ApiUrl = $"{_url}/Authorization/User/{email}/Roles"
            });
        }

        public async Task<T> GetRolesNamesByEmail<T>(string email)
        {
            return await SendAsync<T>(new ApiRequest
            {
                ApiType = Models.Enums.ApiType.GET,
                Data = null,
                Token = string.Empty,
                ApiUrl = $"{_url}/Authorization/User/{email}/Roles/Names"
            });
        }
    }
}
