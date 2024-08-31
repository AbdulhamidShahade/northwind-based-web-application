using FullWebProjectWithAPI.Web.Models.DTOs.EmployeeDTOs;
using System.Linq.Expressions;

namespace FullWebProjectWithAPI.Web.Services.IService
{
    public interface IEmployeeService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(Func<int, int> func, string token);
        Task<T> CreateAsync<T>(CreateEmployeeDto createDto, string token);
        Task<T> UpdateAsync<T>(Func<int, int> func, UpdateEmployeeDto updateDto, string token);
        Task<T> DeleteAsync<T>(Func<int, int> func, string token);
    }
}
