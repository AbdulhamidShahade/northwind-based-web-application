using FullWebProjectWithAPI.Web.Models.Enums;

namespace FullWebProjectWithAPI.Web.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; }
        public string ApiUrl { get; set; }
        public object Data { get; set; }
        public string Token { get; set; }
    }
}
