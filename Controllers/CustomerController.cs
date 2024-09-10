using AutoMapper;
using FullWebProjectWithAPI.Web.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NorthwindBasedWebApplication.Models;
using NorthwindBasedWebApplication.Models.Dtos.CustomerDtos;
using NorthwindBasedWebApplication.Shared;

namespace FullWebProjectWithAPI.Web.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var response = await _customerService.GetAsync<ApiResponse>(x => id, HttpContext.Session.GetString(Shared.SessionToken));

            var category = JsonConvert.DeserializeObject<ReadCustomerDto>(response.data.ToString());

            return View(category);
        }


        [HttpGet]

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCustomerDto createCustomerDto)
        {
            var response = await _customerService.CreateAsync<ApiResponse>(createCustomerDto, HttpContext.Session.GetString(Shared.SessionToken));

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

            var response = await _customerService.GetAsync<ApiResponse>(x => id, HttpContext.Session.GetString(Shared.SessionToken));

            var category = JsonConvert.DeserializeObject<UpdateCustomerDto>(response.data.ToString());

            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, UpdateCustomerDto updateCustomerDto)
        {
            var response = await _customerService.UpdateAsync<ApiResponse>(x => id, updateCustomerDto, HttpContext.Session.GetString(Shared.SessionToken));

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
            var response = await _customerService.GetAsync<ApiResponse>(x => id, HttpContext.Session.GetString(Shared.SessionToken));

            var category = JsonConvert.DeserializeObject<ReadCustomerDto>(response.data.ToString());

            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ReadCustomerDto model)
        {
            var response = await _customerService.DeleteAsync<ApiResponse>(x => model.Id, HttpContext.Session.GetString(Shared.SessionToken));

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
