using KyivDigital.Business.Models;
using KyivDigital.Business.Other;
using KyivDigital.Business.Services.Interfaces;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _httpClient;

        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResponse> LoginAsync(LoginPhoneRequest login)
        {
            var content = HttpConvertor.GetHttpContent(login);
            var response = await _httpClient.PostAsync("api/v3/login", content);
            var loginResponse = JsonSerializer.Deserialize<LoginResponse>(await response.Content.ReadAsStringAsync());
            return loginResponse;
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