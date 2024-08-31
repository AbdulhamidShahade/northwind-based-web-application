using FullWebProjectWithAPI.Web.Models.DTOs.CategoryDTOs;
using FullWebProjectWithAPI.Web.Models.DTOs.ProductDTOs;
using FullWebProjectWithAPI.Web.Models.DTOs.TerritoryDTOs;
using System.Linq.Expressions;

namespace FullWebProjectWithAPI.Web.Services.IService
{
    public interface ITerritoryService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(Func<int, int> func, string token);
        Task<T> CreateAsync<T>(CreateTerritoryDto createDto, string token);
        Task<T> UpdateAsync<T>(Func<int, int> func, UpdateTerritoryDto updateDto, string token);
        Task<T> DeleteAsync<T>(Func<int, int> func, string token);
    }
}
