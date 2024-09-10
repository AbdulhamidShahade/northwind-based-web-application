using AutoMapper;
using FullWebProjectWithAPI.Web.Models;
using FullWebProjectWithAPI.Web.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NorthwindBasedWebApplication.Models;
using NorthwindBasedWebApplication.Models.Dtos.OrderDtos;
using NorthwindBasedWebApplication.Shared;

namespace FullWebProjectWithAPI.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var response = await _orderService.GetAllAsync<ApiResponse>(HttpContext.Session.GetString(Shared.SessionToken));

            var categories = JsonConvert.DeserializeObject<List<ReadOrderDto>>(response.data.ToString());


            return View(categories);

        }


        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var response = await _orderService.GetAsync<ApiResponse>(x => id, HttpContext.Session.GetString(Shared.SessionToken));

            var category = JsonConvert.DeserializeObject<ReadOrderDto>(response.data.ToString());

            return View(category);
        }


        [HttpGet]

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateOrderDto createOrderDto)
        {
            var response = await _orderService.CreateAsync<ApiResponse>(createOrderDto, HttpContext.Session.GetString(Shared.SessionToken));

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

            var response = await _orderService.GetAsync<ApiResponse>(x => id, HttpContext.Session.GetString(Shared.SessionToken));

            var category = JsonConvert.DeserializeObject<UpdateOrderDto>(response.data.ToString());

            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, UpdateOrderDto updateOrderDto)
        {
            var response = await _orderService.UpdateAsync<ApiResponse>(x => id, updateOrderDto, HttpContext.Session.GetString(Shared.SessionToken));

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
            var response = await _orderService.GetAsync<ApiResponse>(x => id, HttpContext.Session.GetString(Shared.SessionToken));

            var category = JsonConvert.DeserializeObject<ReadOrderDto>(response.data.ToString());

            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ReadOrderDto model)
        {
            var response = await _orderService.DeleteAsync<ApiResponse>(x => model.Id, HttpContext.Session.GetString(Shared.SessionToken));

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
