
using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NorthwindBasedWebApplication.Models;
using NorthwindBasedWebApplication.Models.Dtos.CategoryDtos;
using NorthwindBasedWebApplication.Services.IService;
using NorthwindBasedWebApplication.Shared;

namespace FullWebProjectWithAPI.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var response = await _categoryService.GetAllAsync<ApiResponse>(HttpContext.Session.GetString(Shared.SessionToken));

            var categories = JsonConvert.DeserializeObject<List<ReadCategoryDto>>(response.data.ToString());


            return View(categories);

        }


        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var response = await _categoryService.GetAsync<ApiResponse>(x => id, HttpContext.Session.GetString(Shared.SessionToken));

            var category = JsonConvert.DeserializeObject<ReadCategoryDto>(response.data.ToString());

            return View(category);
        }


        [HttpGet]

        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Create(CreateCategoryDto createCategoryDto)
        {
            var response = await _categoryService.CreateAsync<ApiResponse>(createCategoryDto, HttpContext.Session.GetString(Shared.SessionToken));

            if (response.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {

            var response = await _categoryService.GetAsync<ApiResponse>(x => id, HttpContext.Session.GetString(Shared.SessionToken));

            var category = JsonConvert.DeserializeObject<UpdateCategoryDto> (response.data.ToString());

            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, UpdateCategoryDto updateCategoryDto)
        {
            var response = await _categoryService.UpdateAsync<ApiResponse>(x => id, updateCategoryDto, HttpContext.Session.GetString(Shared.SessionToken));

            if (response.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _categoryService.GetAsync<ApiResponse>(x => id, HttpContext.Session.GetString(Shared.SessionToken));

            var category = JsonConvert.DeserializeObject<ReadCategoryDto>(response.data.ToString());

            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ReadCategoryDto model)
        {
            var response = await _categoryService.DeleteAsync<ApiResponse>(x => model.Id, HttpContext.Session.GetString(Shared.SessionToken));

            if(response.IsSuccess && response != null)
            {
                return Ok("Ok");
            }
            else
            {
                return BadRequest("Failed");
            }
        }


        [HttpGet]
        public async Task<IActionResult> UserIndex()
        {
            var categories = await _categoryService.GetAllAsync<ApiResponse>(token: string.Empty);

            var response = JsonConvert.DeserializeObject<List<ReadCategoryDto>>(categories.data.ToString());

            return View(response);
        }
    }
}
