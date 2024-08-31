using FullWebProjectWithAPI.Web.Models.DTOs.CustomerDTOs;
using System.Linq.Expressions;

namespace FullWebProjectWithAPI.Web.Services.IService
{
    public interface ICustomerService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(Func<int, int> func, string token);
        Task<T> CreateAsync<T>(CreateCustomerDto createDto, string token);
        Task<T> UpdateAsync<T>(Func<int, int> func, UpdateCustomerDto updateDto, string token);
        Task<T> DeleteAsync<T>(Func<int, int> func, string token);
    }
}
