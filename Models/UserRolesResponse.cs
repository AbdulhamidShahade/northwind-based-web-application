using System.Net;

namespace NorthwindBasedWebApplication.Models
{
    public class UserRolesResponse
    {
        public bool IsSuccess { get; set; } = true;
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public List<string> ErrorMessages { get; set; }
        public UserRoles UserRoles { get; set; }
    }
}
