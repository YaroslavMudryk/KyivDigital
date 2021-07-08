using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using KyivDigital.MVC.Helper;
using KyivDigital.MVC.Models.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
        private readonly IUserService _userService;
        private readonly ISessionService _sessionService;
        public IdentityController(Business.Services.Interfaces.IAuthenticationService loginService, ISessionService sessionService, IUserService userService)
        {
            _loginService = loginService;
            _sessionService = sessionService;
            _userService = userService;
        }


        public IActionResult Index() => RedirectToAction("Login");


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
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Перевірте дані");
                return View(model);
            }
            if (model.Code != null && model.Code.Length == 4)
            {
                var result = await _loginService.VerifyCodeAsync(new LoginPhoneRequest(model.Phone, model.Code));
                if (result.IsSuccess)
                {
                    await AuthAsync(result.Profile, result.Token.AccessToken);
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
            _sessionService.ClearSessions();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpGet("sso")]
        public async Task<IActionResult> LoginSSO(string accessToken, string returnUrl)
        {
            var response = await _userService.GetUserProfileAsync(accessToken);
            if (response.IsSuccess)
            {
                Uri outUri;
                if (Uri.TryCreate(returnUrl, UriKind.Absolute, out outUri))
                    returnUrl = outUri.PathAndQuery;
                if (!Url.IsLocalUrl(returnUrl))
                {
                    return LocalRedirect("~/identity/login");
                }
                await AuthAsync(response, accessToken);
                return Redirect(returnUrl);
            }
            return LocalRedirect("~/identity/login");
        }

        [Authorize]
        [HttpGet("root")]
        public IActionResult GetClaims()
        {
            return Ok(User.Claims.Select(x => new
            {
                Type = x.Type,
                Value = x.Value
            }));
        }

        private async Task AuthAsync(Profile profile, string token)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, profile.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, "User"));
            claims.Add(new Claim(ClaimTypes.AuthenticationMethod, "Web"));
            claims.Add(new Claim(ClaimTypes.Email, profile.Emails.First().EmailAddress ?? "Test1"));
            claims.Add(new Claim(ClaimTypes.MobilePhone, profile.Phones.First(x => x.Type == "PRIMARY").PhoneNumer ?? "Test1"));
            claims.Add(new Claim("accessToken", token));
            claims.Add(new Claim("FirstName", profile.FirstName ?? "Test1"));
            claims.Add(new Claim("MiddleName", profile.MiddleName ?? "Test1"));
            claims.Add(new Claim("LastName", profile.LastName ?? "Test1"));
            claims.Add(new Claim("Avatar", profile.Avatar ?? "/Picts/Default.jpg"));
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}