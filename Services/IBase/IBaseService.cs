using FullWebProjectWithAPI.Web.Models;
using System.Linq.Expressions;

namespace FullWebProjectWithAPI.Web.Services.IBase
{
    public interface IBaseService
    {
        ApiResponse Response { get; set; }

        Task<T> SendAsync<T>(ApiRequest request);
    }
}
