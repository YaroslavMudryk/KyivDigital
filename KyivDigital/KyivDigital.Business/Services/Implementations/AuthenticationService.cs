using KyivDigital.Business.Models;
using KyivDigital.Business.Helpers;
using KyivDigital.Business.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly IClaimsProvider _claimsProvider;
        public AuthenticationService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            _httpClient = httpClient;
            _claimsProvider = claimsProvider;
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
        public async Task<LoginVerifyResponse> UpdateTokenAsync(LoginPhoneRequest loginPhoneRequest)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            var requestContent = HttpConvertor.GetHttpContent(loginPhoneRequest);
            var response = await _httpClient.PostAsync("api/v3/auth/refresh", requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var authResponse = JsonSerializer.Deserialize<LoginVerifyResponse>(content);
            _claimsProvider.UpdateClaim(new System.Security.Claims.Claim("accessToken", authResponse.TokenModel.AccessToken));
            return authResponse;
        }
        public async Task<BaseResponse> LogoutAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
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
    }
}