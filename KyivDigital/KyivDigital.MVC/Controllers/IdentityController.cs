using KyivDigital.Business.Models;
using KyivDigital.MVC.Helper;
using KyivDigital.MVC.Models.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KyivDigital.MVC.Controllers
{
    [Route("identity")]
    public class IdentityController : Controller
    {
        private readonly Business.Services.Interfaces.IAuthenticationService _loginService;
        public IdentityController(Business.Services.Interfaces.IAuthenticationService loginService)
        {
            _loginService = loginService;
        }


        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }


        [HttpGet("login")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return LocalRedirect("~/");

            return View(new LoginRequest
            {
                IsVerify = false,
                Phone = "+380"
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            if (User.Identity.IsAuthenticated)
                return LocalRedirect("~/");
            if (!MobileHelper.ValidateMobile(model.Phone))
            {
                ModelState.AddModelError("", "Невірний формат телефону");
                return View(model);
            }
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Перевірте дані");
                return View(model);
            }
            if (model.Code != null && model.Code.Length == 4)
            {
                var result = await _loginService.VerifyCodeAsync(new LoginPhoneRequest(model.Phone, model.Code));
                if (result.IsSuccess)
                {
                    await AuthAsync(result);
                    return LocalRedirect("~/");
                }
                ModelState.AddModelError("", result.ErrorMessage);
                return View(model);
            }
            var res = await _loginService.LoginAsync(new LoginPhoneRequest(model.Phone));
            if (res.IsSuccess)
                model.IsVerify = true;
            return View(model);
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            if (!User.Identity.IsAuthenticated)
                return LocalRedirect("~/identity/login");
            var res = _loginService.LogoutAsync();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [Authorize]
        [HttpGet("root")]
        public IActionResult GetClaims()
        {
            return Ok(User.Claims.Select(x=> new
            {
                Type = x.Type,
                Value = x.Value
            }));
        }

        private async Task AuthAsync(TokenResponse tokenResponse)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, tokenResponse.Profile.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, "User"));
            claims.Add(new Claim(ClaimTypes.AuthenticationMethod, "Web"));
            claims.Add(new Claim(ClaimTypes.Email, tokenResponse.Profile.Emails.First().EmailAddress ?? "Test1"));
            claims.Add(new Claim(ClaimTypes.MobilePhone, tokenResponse.Profile.Phones.First(x=>x.Type=="PRIMARY").PhoneNumer ?? "Test1"));
            claims.Add(new Claim("accessToken", tokenResponse.Token.AccessToken));
            claims.Add(new Claim("FirstName",tokenResponse.Profile.FirstName ?? "Test1"));
            claims.Add(new Claim("MiddleName",tokenResponse.Profile.MiddleName ?? "Test1"));
            claims.Add(new Claim("LastName", tokenResponse.Profile.LastName ?? "Test1"));
            claims.Add(new Claim("Avatar", tokenResponse.Profile.Avatar ?? "Test1"));
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}