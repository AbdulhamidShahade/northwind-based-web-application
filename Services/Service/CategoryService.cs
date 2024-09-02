
using FullWebProjectWithAPI.Web.Services.Base;
using NorthwindBasedWebApplication.Models.Dtos.CategoryDtos;
using NorthwindBasedWebApplication.Models;
using NorthwindBasedWebApplication.Models.Enums;
using NorthwindBasedWebApplication.Services.IService;

namespace NorthwindBasedWebApplication.Services.Service
{
    public class CategoryService : BaseService, ICategoryService
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _url;

        public CategoryService(IHttpClientFactory httpClientFactory,
            IConfiguration configuration) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _url = configuration.GetValue<string>("ApiUrls:Base");
        }

        public Task<T> CreateAsync<T>(CreateCategoryDto createDto, string token)
        {
            return SendAsync<T>(new ApiRequest
            {
                ApiType = ApiType.POST,
                Data = createDto,
                Token = token,
                ApiUrl = $"{_url}/category"
            });
        }

        public Task<T> DeleteAsync<T>(Func<int, int> func, string token)
        {
            return SendAsync<T>(new ApiRequest
            {
                ApiType = ApiType.DELETE,
                Token = token,
                ApiUrl = $"{_url}/category/{func(0)}"
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new ApiRequest
            {
                ApiType = ApiType.GET,
                Data = null,
                Token = string.Empty,
                ApiUrl = $"{_url}/categories"
            });
        }

        public Task<T> GetAsync<T>(Func<int, int> func, string token)
        {
            return SendAsync<T>(new ApiRequest
            {
                ApiType = ApiType.GET,
                Token = token,
                ApiUrl = $"{_url}/category/{func(0)}"
            });
        }

        public Task<T> UpdateAsync<T>(Func<int, int> func, UpdateCategoryDto updateDto, string token)
        {
            return SendAsync<T>(new ApiRequest
            {
                ApiType = ApiType.PUT,
                Data = updateDto,
                Token = token,
                ApiUrl = $"{_url}/category/{func(0)}"
            });
        }
    }
}
