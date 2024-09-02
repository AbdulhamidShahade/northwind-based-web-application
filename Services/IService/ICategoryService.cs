

using NorthwindBasedWebApplication.Models.Dtos.CategoryDtos;

namespace NorthwindBasedWebApplication.Services.IService
{
    public interface ICategoryService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(Func<int, int> func, string token);
        Task<T> CreateAsync<T>(CreateCategoryDto createDto, string token);
        Task<T> UpdateAsync<T>(Func<int, int> func, UpdateCategoryDto updateDto, string token);
        Task<T> DeleteAsync<T>(Func<int, int> func, string token);
    }
}
