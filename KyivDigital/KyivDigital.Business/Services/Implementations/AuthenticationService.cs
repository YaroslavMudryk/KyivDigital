using KyivDigital.Business.Helpers;
using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace KyivDigital.Business.Services.Implementations
{
    public class AuthenticationService : Interfaces.IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IClaimsProvider _claimsProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public AuthenticationService(HttpClient httpClient, IClaimsProvider claimsProvider, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _claimsProvider = claimsProvider;
            _httpContextAccessor = httpContextAccessor;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            _configuration = configuration;
        }
        
        public async Task<LoginResponse> LoginAsync(LoginPhoneRequest login)
        {
            var content = HttpConvertor.GetHttpContent(login);
            _httpClient.DefaultRequestHeaders.Add("X-Firebase-AppCheck", _configuration["AppConfig:Firebase"]);
            var response = await _httpClient.PostAsync("api/v3/login", content);
            var loginResponse = JsonSerializer.Deserialize<LoginResponse>(await response.Content.ReadAsStringAsync());
            return loginResponse;
        }
        public async Task<TokenResponse> VerifyCodeAsync(LoginPhoneRequest login)
        {
            var content = HttpConvertor.GetHttpContent(login);
            var response = await _httpClient.PostAsync("api/v3/login/verify", content);
            var verifyResponse = JsonSerializer.Deserialize<TokenResponse>(await response.Content.ReadAsStringAsync());
            await AuthAsync(verifyResponse.Profile, verifyResponse.Token.AccessToken);
            return verifyResponse;
        }
        public async Task<LoginVerifyResponse> UpdateTokenAsync(LoginPhoneRequest loginPhoneRequest)
        {
            var requestContent = HttpConvertor.GetHttpContent(loginPhoneRequest);
            var response = await _httpClient.PostAsync("api/v3/auth/refresh", requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var authResponse = JsonSerializer.Deserialize<LoginVerifyResponse>(content);
            await AuthAsync(authResponse.Profile, authResponse.TokenModel.AccessToken);
            return authResponse;
        }
        public async Task<BaseResponse> LogoutAsync()
        {
            
            var response = await _httpClient.PostAsync("api/v3/auth/logout", null);
            if (response.IsSuccessStatusCode)
                return new BaseResponse
                {
                    ErrorMessage = null
                };
            return new BaseResponse
            {
                ErrorMessage = await response.Content.ReadAsStringAsync()
            };
        }
        public async Task<bool> AuthAsync(Profile profile, string accessToken)
        {
            if (profile == null || string.IsNullOrEmpty(accessToken))
                return false;
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, profile.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, "User"));
            claims.Add(new Claim(ClaimTypes.AuthenticationMethod, "Web"));
            if (profile.Emails.Count > 0)
                claims.Add(new Claim(ClaimTypes.Email, profile.Emails.First().EmailAddress));
            claims.Add(new Claim(ClaimTypes.MobilePhone, profile.Phones[0].PhoneNumber));
            claims.Add(new Claim("accessToken", accessToken));
            claims.Add(new Claim("FirstName", profile.FirstName ?? "Киянин"));
            claims.Add(new Claim("Avatar", profile.Avatar ?? "/Picts/Default.jpg"));
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
            return true;
        }
    }
}