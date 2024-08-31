using FullWebProjectWithAPI.Web.Models.DTOs.CategoryDTOs;
using FullWebProjectWithAPI.Web.Models.DTOs.CustomerDTOs;
using FullWebProjectWithAPI.Web.Services.Base;
using FullWebProjectWithAPI.Web.Services.IService;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;
using static System.Net.WebRequestMethods;

namespace FullWebProjectWithAPI.Web.Services.Service
{
    public class CustomerService : BaseService, ICustomerService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _url;

        public CustomerService(IHttpClientFactory httpClientFactory,
            IConfiguration configuration) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _url = configuration.GetValue<string>("ApiUrls:Base");
        }

        public Task<T> CreateAsync<T>(CreateCustomerDto createDto, string token)
        {
            return SendAsync<T>(new Models.ApiRequest
            {
                ApiType = Models.Enums.ApiType.POST,
                Data = createDto,
                Token = token,
                ApiUrl = $"{_url}/customer"
            });
        }

        public Task<T> CreateAsync<T>(CreateCategoryDto createDto, string token)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync<T>(Func<int, int> func, string token)
        {
            return SendAsync<T>(new Models.ApiRequest
            {
                ApiType = Models.Enums.ApiType.DELETE,
                Data = null,
                Token = token,
                ApiUrl = $"{_url}/Customer/{func(0)}"

                

            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new Models.ApiRequest
            {
                ApiType = Models.Enums.ApiType.GET,
                Data = null,
                Token = token,
                ApiUrl = $"{_url}/customer"
            });
        }

        public Task<T> GetAsync<T>(Func<int, int> func, string token)
        {
            return SendAsync<T>(new Models.ApiRequest
            {
                ApiType = Models.Enums.ApiType.GET,
                Data = null,
                Token = token,
                ApiUrl = $"{_url}/customer/{func(0)}"
            });
        }

        public Task<T> UpdateAsync<T>(Func<int, int> func, UpdateCustomerDto updateDto, string token)
        {
            return SendAsync<T>(new Models.ApiRequest
            {
                ApiType = Models.Enums.ApiType.PUT,
                Data = updateDto,
                Token = token,
                ApiUrl = $"{_url}/customer/{func(0)}"
            });
        }

        
    }
}
