using AutoMapper;
using FullWebProjectWithAPI.Web.Models.DTOs.CategoryDTOs;
using FullWebProjectWithAPI.Web.Models.DTOs.CustomerDTOs;
using FullWebProjectWithAPI.Web.Models;
using FullWebProjectWithAPI.Web.Services.IService;
using FullWebProjectWithAPI.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FullWebProjectWithAPI.Web.Models.DTOs.CustomerDemographicDTOs;

namespace FullWebProjectWithAPI.Web.Controllers
{
    public class CustomerDemographicController : Controller
    {
        private readonly ICustomerDemographicService _customerDemographicService;
        private readonly IMapper _mapper;

        public CustomerDemographicController(ICustomerDemographicService customerDemographicService, IMapper mapper)
        {
            _customerDemographicService = customerDemographicService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var response = await _customerDemographicService.GetAllAsync<ApiResponse>(HttpContext.Session.GetString(Shared.SessionToken));

            var categories = JsonConvert.DeserializeObject<List<ReadCustomerDemographicDto>>(response.data.ToString());


            return View(categories);

        }


        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var response = await _customerDemographicService.GetAsync<ApiResponse>(x => id, HttpContext.Session.GetString(Shared.SessionToken));

            var category = JsonConvert.DeserializeObject<ReadCustomerDemographicDto>(response.data.ToString());

            return View(category);
        }


        [HttpGet]

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCustomerDemographicDto createCustomerDemographicDto)
        {
            var response = await _customerDemographicService.CreateAsync<ApiResponse>(createCustomerDemographicDto, HttpContext.Session.GetString(Shared.SessionToken));

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

            var response = await _customerDemographicService.GetAsync<ApiResponse>(x => id, HttpContext.Session.GetString(Shared.SessionToken));

            var category = JsonConvert.DeserializeObject<UpdateCustomerDemographicDto>(response.data.ToString());

            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, UpdateCustomerDemographicDto updateCustomerDemographicDto)
        {
            var response = await _customerDemographicService.UpdateAsync<ApiResponse>(x => id, updateCustomerDemographicDto, HttpContext.Session.GetString(Shared.SessionToken));

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
            var response = await _customerDemographicService.GetAsync<ApiResponse>(x => id, HttpContext.Session.GetString(Shared.SessionToken));

            var category = JsonConvert.DeserializeObject<ReadCustomerDemographicDto>(response.data.ToString());

            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ReadCategoryDto model)
        {
            var response = await _customerDemographicService.DeleteAsync<ApiResponse>(x => model.Id, HttpContext.Session.GetString(Shared.SessionToken));

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
