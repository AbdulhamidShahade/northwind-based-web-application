using AutoMapper;
using FullWebProjectWithAPI.Web.Models.DTOs.CategoryDTOs;
using FullWebProjectWithAPI.Web.Models.DTOs.CustomerDTOs;
using FullWebProjectWithAPI.Web.Models;
using FullWebProjectWithAPI.Web.Services.IService;
using FullWebProjectWithAPI.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FullWebProjectWithAPI.Web.Models.DTOs.ProductDTOs;

namespace FullWebProjectWithAPI.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var response = await _productService.GetAllAsync<ApiResponse>(HttpContext.Session.GetString(Shared.SessionToken));

            var categories = JsonConvert.DeserializeObject<List<ReadProductDto>>(response.data.ToString());


            return View(categories);

        }


        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var response = await _productService.GetAsync<ApiResponse>(x => id, HttpContext.Session.GetString(Shared.SessionToken));

            var category = JsonConvert.DeserializeObject<ReadProductDto>(response.data.ToString());

            return View(category);
        }


        [HttpGet]

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateProductDto createProductDto)
        {
            var response = await _productService.CreateAsync<ApiResponse>(createProductDto, HttpContext.Session.GetString(Shared.SessionToken));

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

            var response = await _productService.GetAsync<ApiResponse>(x => id, HttpContext.Session.GetString(Shared.SessionToken));

            var category = JsonConvert.DeserializeObject<UpdateProductDto>(response.data.ToString());

            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, UpdateProductDto updateProductDto)
        {
            var response = await _productService.UpdateAsync<ApiResponse>(x => id, updateProductDto, HttpContext.Session.GetString(Shared.SessionToken));

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
            var response = await _productService.GetAsync<ApiResponse>(x => id, HttpContext.Session.GetString(Shared.SessionToken));

            var category = JsonConvert.DeserializeObject<ReadProductDto>(response.data.ToString());

            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ReadCategoryDto model)
        {
            var response = await _productService.DeleteAsync<ApiResponse>(x => model.Id, HttpContext.Session.GetString(Shared.SessionToken));

            if (response.IsSuccess && response != null)
            {
                return Ok("Ok");
            }
            else
            {
                return BadRequest("Failed");
            }
        }
    }
}
