using FullWebProjectWithAPI.Web.Models.DTOs.SupplierDTOs;
using FullWebProjectWithAPI.Web.Services.Base;
using FullWebProjectWithAPI.Web.Services.IService;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq.Expressions;

namespace FullWebProjectWithAPI.Web.Services.Service
{
    public class SupplierService : BaseService, ISupplierService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _url;

        public SupplierService(IHttpClientFactory httpClientFactory,
            IConfiguration configuration) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _url = configuration.GetValue<string>("ApiUrls:Base");
        }

        public Task<T> CreateAsync<T>(CreateSupplierDto createDto, string token)
        {
            return SendAsync<T>(new Models.ApiRequest
            {
                Data = createDto,
                Token = token,
                ApiType = Models.Enums.ApiType.POST,
                ApiUrl = $"{_url}/supplier"
            });
        }

        public Task<T> DeleteAsync<T>(Func<int, int> func, string token)
        {
            return SendAsync<T>(new Models.ApiRequest
            {
                Data = null,
                Token = token,
                ApiType = Models.Enums.ApiType.POST,
                ApiUrl = $"{_url}/supplier/{func(0)}"
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new Models.ApiRequest
            {
                Data = null,
                Token = token,
                ApiType = Models.Enums.ApiType.GET,
                ApiUrl = $"{_url}/supplier"
            });
        }

        public Task<T> GetAsync<T>(Func<int, int> func, string token)
        {
            return SendAsync<T>(new Models.ApiRequest
            {
                Data = null,
                Token = token,
                ApiType = Models.Enums.ApiType.GET,
                ApiUrl = $"{_url}/supplier/{func(0)}"
            });
        }

        public Task<T> UpdateAsync<T>(Func<int, int> func, UpdateSupplierDto updateDto, string token)
        {
            return SendAsync<T>(new Models.ApiRequest
            {
                Data = updateDto,
                Token = token,
                ApiType = Models.Enums.ApiType.PUT,
                ApiUrl = $"{_url}/supplier/{func(0)}"
            });
        }
    }
}
