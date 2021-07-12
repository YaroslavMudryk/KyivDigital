using KyivDigital.Business.Helpers;
using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace KyivDigital.Business.Services.Implementations
{
    public class HourlyParkingServiceV4 : IHourlyParkingService
    {
        private readonly HttpClient _httpClient;
        private readonly IClaimsProvider _claimsProvider;
        public HourlyParkingServiceV4(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            _httpClient = httpClient;
            _claimsProvider = claimsProvider;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
        }

        public async Task<HourlyParkingListResponse> GetHourlyParkingListAsync()
        {
            string url = "api/v4/hourly-parking/list";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<HourlyParkingListResponse>(content);
            return voteResponse;
        }

        public async Task<HourlyParkingListResponse> GetHourlyParkingNewAsync(double lat, double lng)
        {
            string url = $"api/v4/hourly-parking/data?lat={lat}&lng={lng}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<HourlyParkingListResponse>(content);
            return voteResponse;
        }

        public async Task<ActiveSession> StartHourlyParkingAsync(HourlyParkingStartRequest hourlyParkingStartRequest)
        {
            string url = "api/v4/hourly-parking/session/start";
            var requestContent = HttpConvertor.GetHttpContent(hourlyParkingStartRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<ActiveSession>(content);
            return voteResponse;
        }
    }
}