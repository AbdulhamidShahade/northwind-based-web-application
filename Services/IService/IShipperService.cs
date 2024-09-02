
using NorthwindBasedWebApplication.Models.Dtos.ShipperDtos;
using System.Linq.Expressions;

namespace FullWebProjectWithAPI.Web.Services.IService
{
    public interface IShipperService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(Func<int, int> func, string token);
        Task<T> CreateAsync<T>(CreateShipperDto createDto, string token);
        Task<T> UpdateAsync<T>(Func<int, int> func, UpdateShipperDto updateDto, string token);
        Task<T> DeleteAsync<T>(Func<int, int> func, string token);
    }
}
