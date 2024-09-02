
using Microsoft.AspNetCore.Mvc;
using NorthwindBasedWebApplication.Models;
using NorthwindBasedWebApplication.Models.Dtos.AuthenticationDtos;
using NorthwindBasedWebApplication.Services.IService;

namespace NorthwindBasedWebApplication.Controllers
{
    public class AuthenticationController : Controller
    {

        private readonly IAuthenticationService _authenticationService;
        private readonly GlobalSettings _globalSettings;

        public AuthenticationController(IAuthenticationService authenticationService, GlobalSettings globalSettings)
        {
            _authenticationService = authenticationService;
            _globalSettings = globalSettings;
        }

        [HttpGet]
        public async Task<ActionResult> Login()
        {
            return View(new LoginRequestDto());
        }


        [HttpPost]
        public async Task<ActionResult> LoginConfirmed(LoginRequestDto loginRequestDto)
        {
            ApiResponse loginResponseDto = await _authenticationService.Login<ApiResponse>(loginRequestDto);

            if (!loginResponseDto.IsSuccess)
            {
                _globalSettings.IsAuthenticatedUser = false;
                _globalSettings.Email = loginRequestDto.Email;

                return PartialView("_Main");
            }
            else
            {
                _globalSettings.IsAuthenticatedUser = true;
                _globalSettings.Email = loginRequestDto.Email;

                return PartialView("_Main");
            }
        }

        [HttpGet]
        public async Task<ActionResult> Register()
        {
            return View(new RegisterRequestDto());
        }


        [HttpPost]
        public async Task<ActionResult> RegisterConfirmed(RegisterRequestDto registerRequestDto)
        {
            RegisterResponseDto registerResponse = await _authenticationService.Register<RegisterResponseDto>(registerRequestDto);

            if(registerResponse == null)
            {
                _globalSettings.IsAuthenticatedUser = false;

                return PartialView("_Main");
            }
            else
            {
                _globalSettings.IsAuthenticatedUser = false;

                return PartialView("_Main");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            _globalSettings.IsAuthenticatedUser = false;
            return PartialView("_Main");
        }
    }
}
