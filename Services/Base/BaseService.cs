using FullWebProjectWithAPI.Web.Models;
using FullWebProjectWithAPI.Web.Services.IBase;
using Newtonsoft.Json;
using NorthwindBasedWebApplication.Models;
using NorthwindBasedWebApplication.Models.Enums;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace FullWebProjectWithAPI.Web.Services.Base
{
    public class BaseService : IBaseService
    {
        public ApiResponse Response { get; set; }

        private IHttpClientFactory _httpClientFactory { get; set; }

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            
            Response = new();
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Northwind");
                HttpRequestMessage message = new HttpRequestMessage();

                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.ApiUrl);

                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");

                }

                switch (apiRequest.ApiType)
                {
                    case ApiType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                }

                if (!string.IsNullOrEmpty(apiRequest.Token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.Token);
                }

                HttpResponseMessage apiResponse = null;

                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();


                try
                {
                    T response = JsonConvert.DeserializeObject<T>(apiContent);

                    
                }

                catch (Exception ex)
                {
                    var res = JsonConvert.DeserializeObject<T>(apiContent);

                    return res;
                }

                var ress = JsonConvert.DeserializeObject<T>(apiContent);

                return ress;
            }
            catch (Exception ex)
            {
                var dto = new ApiResponse
                {
                    ErrorMessages = new List<string> { Convert.ToString(ex.Message) },
                    IsSuccess = false
                };

                var res = JsonConvert.SerializeObject(dto);
                var apiResponse = JsonConvert.DeserializeObject<T>(res);

                return apiResponse;
            }
        }
    }
}
