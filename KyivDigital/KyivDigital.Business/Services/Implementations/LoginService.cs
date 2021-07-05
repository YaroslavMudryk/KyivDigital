using KyivDigital.Business.Models;
using KyivDigital.Business.Other;
using KyivDigital.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<LoginResponse> LoginAsync(LoginPhoneRequest login)
        {
            var content = HttpConvertor.GetHttpContent(login);
            var response = await _httpClient.PostAsync("api/v3/login", content);
            var loginResponse = JsonSerializer.Deserialize<LoginResponse>(await response.Content.ReadAsStringAsync());
            return loginResponse;
        }

        public async Task<BaseResponse> LogoutAsync()
        {
            var token = _httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == "accessToken");
            if (token != null)
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
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

        public async Task<TokenResponse> VerifyCodeAsync(LoginPhoneRequest login)
        {
            var content = HttpConvertor.GetHttpContent(login);
            var response = await _httpClient.PostAsync("api/v3/login/verify", content);
            var verifyResponse = JsonSerializer.Deserialize<TokenResponse>(await response.Content.ReadAsStringAsync());
            return verifyResponse;
        }
    }
}