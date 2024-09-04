

using NorthwindBasedWebApplication.Models.Enums;

namespace NorthwindBasedWebApplication.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; }
        public string ApiUrl { get; set; }
        public object Data { get; set; }
        public string Token { get; set; }
    }
}
