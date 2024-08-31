using AutoMapper;
using FullWebProjectWithAPI.Web.Models.DTOs.CategoryDTOs;
using FullWebProjectWithAPI.Web.Models.DTOs.CustomerDTOs;
using FullWebProjectWithAPI.Web.Models;
using FullWebProjectWithAPI.Web.Services.IService;
using FullWebProjectWithAPI.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FullWebProjectWithAPI.Web.Models.DTOs.RegionDTOs;

namespace FullWebProjectWithAPI.Web.Controllers
{
    public class RegionController : Controller
    {
        private readonly IRegionService _regionService;
        private readonly IMapper _mapper;

        public RegionController(IRegionService regionService, IMapper mapper)
        {
            _regionService = regionService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var response = await _regionService.GetAllAsync<ApiResponse>(HttpContext.Session.GetString(Shared.SessionToken));

            var categories = JsonConvert.DeserializeObject<List<ReadRegionDto>>(response.data.ToString());


            return View(categories);

        }


        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var response = await _regionService.GetAsync<ApiResponse>(x => id, HttpContext.Session.GetString(Shared.SessionToken));

            var category = JsonConvert.DeserializeObject<ReadRegionDto>(response.data.ToString());

            return View(category);
        }


        [HttpGet]

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateRegionDto createRegionDto)
        {
            var response = await _regionService.CreateAsync<ApiResponse>(createRegionDto, HttpContext.Session.GetString(Shared.SessionToken));

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

            var response = await _regionService.GetAsync<ApiResponse>(x => id, HttpContext.Session.GetString(Shared.SessionToken));

            var category = JsonConvert.DeserializeObject<UpdateRegionDto>(response.data.ToString());

            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, UpdateRegionDto updateRegionDto)
        {
            var response = await _regionService.UpdateAsync<ApiResponse>(x => id, updateRegionDto, HttpContext.Session.GetString(Shared.SessionToken));

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
            var response = await _regionService.GetAsync<ApiResponse>(x => id, HttpContext.Session.GetString(Shared.SessionToken));

            var category = JsonConvert.DeserializeObject<ReadRegionDto>(response.data.ToString());

            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ReadCategoryDto model)
        {
            var response = await _regionService.DeleteAsync<ApiResponse>(x => model.Id, HttpContext.Session.GetString(Shared.SessionToken));

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
