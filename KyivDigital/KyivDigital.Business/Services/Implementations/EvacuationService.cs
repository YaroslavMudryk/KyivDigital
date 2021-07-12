using KyivDigital.Business.Helpers;
using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Implementations
{
    public class EvacuationService : IEvacuationService
    {
        private readonly HttpClient _httpClient;
        private readonly IClaimsProvider _claimsProvider;
        public EvacuationService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            _httpClient = httpClient;
            _claimsProvider = claimsProvider;
        }

        public async Task<CheckEvacuationCarResponse> CheckEvacuatedCarAsync(EvacuationCarRequest evacuationCarRequest)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = "api/v3/evacuation/check";
            var requestContent = HttpConvertor.GetHttpContent(evacuationCarRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<CheckEvacuationCarResponse>(content);
            return voteResponse;
        }

        public async Task<BaseResponse> ConfirmEvacuationCarAsync(long id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/evacuation/return/{id}/confirm";
            var response = await _httpClient.PostAsync(url, null);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<BaseResponse>(content);
            return voteResponse;
        }

        public async Task<GetEvacuationCarResponse> GetEvacuatedCarsAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = "api/v3/evacuation";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<GetEvacuationCarResponse>(content);
            return voteResponse;
        }

        public async Task<GooglePayDataResponse> GetEvacuationGooglePayDataAsync(long id, EvacuationPaymentRequest evacuationPaymentRequest)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/evacuation/return/{id}/penalty-payment?dry_run_google=1";
            var requestContent = HttpConvertor.GetHttpContent(evacuationPaymentRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<GooglePayDataResponse>(content);
            return voteResponse;
        }

        public async Task<GetEvacuationPaymentResponse> GetEvacuationPaymentAsync(long id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/evacuation/return/{id}/penalty-payment";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<GetEvacuationPaymentResponse>(content);
            return voteResponse;
        }

        public async Task<EvacuationStatus> GetEvacuationStatusAsync(long id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/evacuation/return/{id}/status";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<EvacuationStatus>(content);
            return voteResponse;
        }

        public async Task<GetEvacuationPaymentResponse> GetEvacuationSurchargeAsync(long id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/evacuation/return/{id}/surcharge";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<GetEvacuationPaymentResponse>(content);
            return voteResponse;
        }

        public async Task<GooglePayDataResponse> GetEvacuationSurchargeGooglePayDataAsync(long id, EvacuationPaymentRequest evacuationPaymentRequest)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/evacuation/return/{id}/surcharge?dry_run_google=1";
            var requestContent = HttpConvertor.GetHttpContent(evacuationPaymentRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<GooglePayDataResponse>(content);
            return voteResponse;
        }

        public async Task<PaymentResponse> MakeEvacuationPaymentAsync(long id, EvacuationPaymentRequest evacuationPaymentRequest)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/evacuation/return/{id}/penalty-payment";
            var requestContent = HttpConvertor.GetHttpContent(evacuationPaymentRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<PaymentResponse>(content);
            return voteResponse;
        }

        public async Task<PaymentResponse> MakeEvacuationSurchargePaymentAsync(long id, EvacuationPaymentRequest evacuationPaymentRequest)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/evacuation/return/{id}/surcharge";
            var requestContent = HttpConvertor.GetHttpContent(evacuationPaymentRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<PaymentResponse>(content);
            return voteResponse;
        }
    }
}