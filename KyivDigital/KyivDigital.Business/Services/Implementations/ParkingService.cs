using KyivDigital.Business.Helpers;
using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace KyivDigital.Business.Services.Implementations
{
    public class ParkingService : IParkingService
    {
        private readonly HttpClient _httpClient;
        private readonly IClaimsProvider _claimsProvider;
        public ParkingService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            _httpClient = httpClient;
            _claimsProvider = claimsProvider;
        }

        public async Task<ParkingBayResponse> GetParkingBayAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = "api/v3/parking/buy";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<ParkingBayResponse>(content);
            return voteResponse;
        }

        public async Task<GooglePayDataResponse> GetParkingGooglePayDataAsync(ParkingPaymentRequest parkingPaymentRequest)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = "api/v3/parking/buy?dry_run_google=1";
            var requestContent = HttpConvertor.GetHttpContent(parkingPaymentRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<GooglePayDataResponse>(content);
            return voteResponse;
        }

        public async Task<ParkingSubscriptionsResponse> GetParkingSubscriptionsArchiveAsync(int page)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/parking/tickets-archive?page={page}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<ParkingSubscriptionsResponse>(content);
            return voteResponse;
        }

        public async Task<ParkingSubscriptionsResponse> GetParkingSubscriptionsAsync(int page)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/parking/tickets?page={page}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<ParkingSubscriptionsResponse>(content);
            return voteResponse;
        }

        public async Task<ParkingZonesResponse> GetParkingZonesAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = "api/v3/parking/zones";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<ParkingZonesResponse>(content);
            return voteResponse;
        }

        public async Task<ZonePricesResponse> GetZonePricesAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = "api/v3/parking/prices";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<ZonePricesResponse>(content);
            return voteResponse;
        }

        public async Task<PaymentResponse> MakeParkingPaymentAsync(ParkingPaymentRequest parkingPaymentRequest)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = "api/v3/parking/buy";
            var requestContent = HttpConvertor.GetHttpContent(parkingPaymentRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<PaymentResponse>(content);
            return voteResponse;
        }
    }
}