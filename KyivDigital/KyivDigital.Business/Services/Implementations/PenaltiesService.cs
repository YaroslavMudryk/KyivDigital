using KyivDigital.Business.Helpers;
using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace KyivDigital.Business.Services.Implementations
{
    public class PenaltiesService : IPenaltiesService
    {
        private readonly HttpClient _httpClient;
        private readonly IClaimsProvider _claimsProvider;
        public PenaltiesService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            _httpClient = httpClient;
            _claimsProvider = claimsProvider;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
        }

        public async Task<FineCheckCarResponse> CheckFineCarAsync(FineCheckCarRequest fineCheckCarRequest)
        {
            string url = "api/v3/penalties/check";
            var requestContent = HttpConvertor.GetHttpContent(fineCheckCarRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<FineCheckCarResponse>(content);
            return voteResponse;
        }

        public async Task<GooglePayDataResponse> GetFineGooglePayDataAsync(string id, FinePaymentRequest finePaymentRequest)
        {
            string url = $"api/v3/penalties/pay/{id}?dry_run_google=1";
            var requestContent = HttpConvertor.GetHttpContent(finePaymentRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<GooglePayDataResponse>(content);
            return voteResponse;
        }

        public async Task<FinePaymentResponse> GetFinePaymentDetailsByIdAsync(string id)
        {
            string url = $"api/v3/penalties/{id}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<FinePaymentResponse>(content);
            return voteResponse;
        }

        public async Task<FinesPaymentFeedResponse> GetFinePaymentsFeedAsync(int page = 1)
        {
            string url = $"api/v3/penalties/feed?page={page}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<FinesPaymentFeedResponse>(content);
            return voteResponse;
        }

        public async Task<FinesResponse> GetFinesAsync()
        {
            string url = "api/v3/penalties";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<FinesResponse>(content);
            return voteResponse;
        }

        public async Task<FinesRegionsResponse> GetFinesRegionsAsync()
        {
            string url = "api/v3/penalties/regions";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<FinesRegionsResponse>(content);
            return voteResponse;
        }

        public async Task<GooglePayDataResponse> GetRawFineGooglePayDataAsync(FinePaymentRequest finePaymentRequest)
        {
            string url = "api/v3/penalties/raw-payment?dry_run_google=1";
            var requestContent = HttpConvertor.GetHttpContent(finePaymentRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<GooglePayDataResponse>(content);
            return voteResponse;
        }

        public async Task<PaymentResponse> MakeFinePaymentAsync(string id, FinePaymentRequest finePaymentRequest)
        {
            string url = $"api/v3/penalties/pay/{id}";
            var requestContent = HttpConvertor.GetHttpContent(finePaymentRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<PaymentResponse>(content);
            return voteResponse;
        }

        public async Task<PaymentResponse> MakeRawFinePaymentAsync(FinePaymentRequest finePaymentRequest)
        {
            string url = "api/v3/penalties/raw-payment";
            var requestContent = HttpConvertor.GetHttpContent(finePaymentRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<PaymentResponse>(content);
            return voteResponse;
        }
    }
}