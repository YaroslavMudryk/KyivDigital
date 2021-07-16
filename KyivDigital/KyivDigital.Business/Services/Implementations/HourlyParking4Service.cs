using KyivDigital.Business.Helpers;
using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using KyivDigital.Business.WebHandlers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace KyivDigital.Business.Services.Implementations
{
    public class HourlyParkingServiceV4 : IHourlyParkingService
    {
        private readonly KyivDigitalRequest _kyivDigitalRequest;
        public HourlyParkingServiceV4(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            var token = claimsProvider.GetAccessToken();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _kyivDigitalRequest = new KyivDigitalRequest(httpClient);
        }

        public async Task<HourlyParkingListResponse> GetHourlyParkingListAsync()
        {
            string url = "api/v4/hourly-parking/list";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<HourlyParkingListResponse>(content);
            return voteResponse;
        }

        public async Task<HourlyParkingListResponse> GetHourlyParkingNewAsync(double lat, double lng)
        {
            string url = $"api/v4/hourly-parking/data?lat={lat}&lng={lng}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<HourlyParkingListResponse>(content);
            return voteResponse;
        }

        public async Task<ActiveSession> StartHourlyParkingAsync(HourlyParkingStartRequest hourlyParkingStartRequest)
        {
            string url = "api/v4/hourly-parking/session/start";
            var response = await _kyivDigitalRequest.PostAsync(url, hourlyParkingStartRequest);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<ActiveSession>(content);
            return voteResponse;
        }
    }
}