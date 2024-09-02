using FullWebProjectWithAPI.Web.Services.Base;
using Microsoft.AspNetCore.Authentication;
using NorthwindBasedWebApplication.Models;
using NorthwindBasedWebApplication.Models.Dtos.AuthenticationDtos;
using NorthwindBasedWebApplication.Services.IService;
using System.Security.Claims;

namespace NorthwindBasedWebApplication.Services.Service
{
    public class AuthenticationService : BaseService, NorthwindBasedWebApplication.Services.IService.IAuthenticationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _url;

        public AuthenticationService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _url = configuration.GetValue<string>("ApiUrls:Base");
        }

        public async Task<T> Login<T>(LoginRequestDto loginRequestDto)
        {
            return await SendAsync<T>(new ApiRequest
            {
                ApiType = Models.Enums.ApiType.POST,
                Data = loginRequestDto,
                ApiUrl = $"{_url}/Authentication/Login",
                Token = string.Empty,
            });
        }
        public async Task<T> Register<T>(RegisterRequestDto registerRequestDto)
        {
            return await SendAsync<T>(new ApiRequest
            {
                ApiType = Models.Enums.ApiType.POST,
                Data = registerRequestDto,
                ApiUrl = $"{_url}/Authentication/Register",
                Token = string.Empty,
            });
        }
    }
}
