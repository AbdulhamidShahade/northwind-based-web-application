using FullWebProjectWithAPI.Web.Models.DTOs.CategoryDTOs;
using FullWebProjectWithAPI.Web.Models.DTOs.ProductDTOs;
using System.Linq.Expressions;

namespace FullWebProjectWithAPI.Web.Services.IService
{
    public interface IProductService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(Func<int, int> func, string token);
        Task<T> CreateAsync<T>(CreateProductDto createDto, string token);
        Task<T> UpdateAsync<T>(Func<int, int> func, UpdateProductDto updateDto, string token);
        Task<T> DeleteAsync<T>(Func<int, int> func, string token);
    }
}
