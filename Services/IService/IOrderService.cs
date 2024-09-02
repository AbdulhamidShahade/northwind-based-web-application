
using NorthwindBasedWebApplication.Models.Dtos.OrderDtos;
using System.Linq.Expressions;

namespace FullWebProjectWithAPI.Web.Services.IService
{
    public interface IOrderService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(Func<int, int> func, string token);
        Task<T> CreateAsync<T>(CreateOrderDto createDto, string token);
        Task<T> UpdateAsync<T>(Func<int, int> func, UpdateOrderDto updateDto, string token);
        Task<T> DeleteAsync<T>(Func<int, int> func, string token);
    }
}
