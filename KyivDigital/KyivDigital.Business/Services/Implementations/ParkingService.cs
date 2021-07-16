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
    public class ParkingService : IParkingService
    {
        private readonly KyivDigitalRequest _kyivDigitalRequest;
        public ParkingService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            var token = claimsProvider.GetAccessToken();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _kyivDigitalRequest = new KyivDigitalRequest(httpClient);
        }

        public async Task<ParkingBayResponse> GetParkingBayAsync()
        {
            string url = "api/v3/parking/buy";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<ParkingBayResponse>(content);
            return voteResponse;
        }

        public async Task<GooglePayDataResponse> GetParkingGooglePayDataAsync(ParkingPaymentRequest parkingPaymentRequest)
        {
            string url = "api/v3/parking/buy?dry_run_google=1";
            var response = await _kyivDigitalRequest.PostAsync(url, parkingPaymentRequest);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<GooglePayDataResponse>(content);
            return voteResponse;
        }

        public async Task<ParkingSubscriptionsResponse> GetParkingSubscriptionsArchiveAsync(int page)
        {
            string url = $"api/v3/parking/tickets-archive?page={page}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<ParkingSubscriptionsResponse>(content);
            return voteResponse;
        }

        public async Task<ParkingSubscriptionsResponse> GetParkingSubscriptionsAsync(int page)
        {
            string url = $"api/v3/parking/tickets?page={page}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<ParkingSubscriptionsResponse>(content);
            return voteResponse;
        }

        public async Task<ParkingZonesResponse> GetParkingZonesAsync()
        {
            string url = "api/v3/parking/zones";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<ParkingZonesResponse>(content);
            return voteResponse;
        }

        public async Task<ZonePricesResponse> GetZonePricesAsync()
        {
            string url = "api/v3/parking/prices";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<ZonePricesResponse>(content);
            return voteResponse;
        }

        public async Task<PaymentResponse> MakeParkingPaymentAsync(ParkingPaymentRequest parkingPaymentRequest)
        {
            string url = "api/v3/parking/buy";
            var response = await _kyivDigitalRequest.PostAsync(url, parkingPaymentRequest);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<PaymentResponse>(content);
            return voteResponse;
        }
    }
}