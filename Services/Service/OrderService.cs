using FullWebProjectWithAPI.Web.Models.DTOs.OrderDTOs;
using FullWebProjectWithAPI.Web.Services.Base;
using FullWebProjectWithAPI.Web.Services.IService;
using System.Linq.Expressions;

namespace FullWebProjectWithAPI.Web.Services.Service
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _url;

        public OrderService(IHttpClientFactory httpClientFactory,
            IConfiguration configuration) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _url = configuration.GetValue<string>("ApiUrls:Base");
        }

        public Task<T> CreateAsync<T>(CreateOrderDto createDto, string token)
        {
            return SendAsync<T>(new Models.ApiRequest
            {
                ApiType = Models.Enums.ApiType.POST,
                Data = createDto,
                Token = token,
                ApiUrl = $"{_url}/order"
            });
        }

        public Task<T> DeleteAsync<T>(Func<int, int> func, string token)
        {
            return SendAsync<T>(new Models.ApiRequest
            {
                ApiType = Models.Enums.ApiType.DELETE,
                Data = null,
                Token = token,
                ApiUrl = $"{_url}/order/{func(0)}"
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new Models.ApiRequest
            {
                ApiType = Models.Enums.ApiType.GET,
                Data = null,
                Token = token,
                ApiUrl = $"{_url}/order"
            });
        }

        public Task<T> GetAsync<T>(Func<int, int> func, string token)
        {
            return SendAsync<T>(new Models.ApiRequest
            {
                ApiType = Models.Enums.ApiType.GET,
                Data = null,
                Token = token,
                ApiUrl = $"{_url}/order/{func(0)}"
            });
        }

        public Task<T> UpdateAsync<T>(Func<int, int> func, UpdateOrderDto updateDto, string token)
        {
            return SendAsync<T>(new Models.ApiRequest
            {
                ApiType = Models.Enums.ApiType.PUT,
                Data = updateDto,
                Token = token,
                ApiUrl = $"{_url}/order/{func(0)}"
            });
        }
    }
}
