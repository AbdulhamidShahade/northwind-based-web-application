using NorthwindBasedWebApplication.Models.Dtos.AuthenticationDtos;
using System.Net;

namespace NorthwindBasedWebApplication.Models
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; } = true;
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public List<string> ErrorMessages { get; set; }
        public object data { get; set; }
    }
}
