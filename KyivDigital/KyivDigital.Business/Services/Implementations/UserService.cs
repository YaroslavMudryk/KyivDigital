using KyivDigital.Business.Helpers;
using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly IClaimsProvider _claimsProvider;
        public UserService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            _httpClient = httpClient;
            _claimsProvider = claimsProvider;
        }

        public async Task<AdressesListModel> GetUserAdressesAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            var url = "api/v3/user/addresses";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var addressResponse = JsonSerializer.Deserialize<AdressesListModel>(content);
            return addressResponse;
        }

        public async Task<NotificationsResponse> GetUserNotificationsAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            var url = "api/v3/user/subscriptions";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var notificationResponse = JsonSerializer.Deserialize<NotificationsResponse>(content);
            return notificationResponse;
        }

        public async Task<Profile> GetUserProfileAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            var url = "api/v3/user/profile";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<Profile>(content);
            return feedResponse;
        }

        public async Task<Profile> GetUserProfileAsync(string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var url = "api/v3/user/profile";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<Profile>(content);
            return feedResponse;
        }

        public async Task<Addresse> SaveAddressAsync(AddOrEditAddressRequest addOrEditAddressRequest)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            var url = "api/v3/user/addresses";
            var requestContent = HttpConvertor.GetHttpContent(addOrEditAddressRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var addressResponse = JsonSerializer.Deserialize<Addresse>(content);
            return addressResponse;
        }
    }
}