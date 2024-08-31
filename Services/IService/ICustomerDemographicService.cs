using FullWebProjectWithAPI.Web.Models.DTOs.CustomerDemographicDTOs;
using NorthwindTask.API.Models.DTOs.CustomerCustomerDemographicDTOs;
using System.Linq.Expressions;

namespace FullWebProjectWithAPI.Web.Services.IService
{
    public interface ICustomerDemographicService
    { 
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(Func<int, int> func, string token);
        Task<T> CreateAsync<T>(CreateCustomerDemographicDto createDto, string token);
        Task<T> UpdateAsync<T>(Func<int, int> func,
            UpdateCustomerDemographicDto updateDto, string token);
        Task<T> DeleteAsync<T>(Func<int, int> func, string token);
    }
}
