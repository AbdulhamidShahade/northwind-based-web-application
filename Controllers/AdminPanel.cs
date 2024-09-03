using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NorthwindBasedWebApplication.Models;
using NorthwindBasedWebApplication.Models.Dtos.CategoryDtos;
using NorthwindBasedWebApplication.Services.IService;

namespace NorthwindBasedWebApplication.Controllers
{
    public class AdminPanel : Controller
    {
        private readonly ICategoryService _categoryService;

        public AdminPanel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync<ApiResponse>(token: string.Empty);

            var response = JsonConvert.DeserializeObject<List<ReadCategoryDto>>(categories.data.ToString());

            return View(response);
        }
    }
}
