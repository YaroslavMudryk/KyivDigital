using KyivDigital.Business.Helpers;
using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Implementations
{
    public class KyivService : IKyivService
    {
        private readonly HttpClient _httpClient;
        private readonly IClaimsProvider _claimsProvider;
        public KyivService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            _httpClient = httpClient;
            _claimsProvider = claimsProvider;
        }

        public async Task<ServiceModel> GetServiceInfoAsync(long id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/services/{id}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<ServiceModel>(content);
            return feedResponse;
        }

        public async Task<ServiceResponse> GetServicesAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = "api/v3/services";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<ServiceResponse>(content);
            return feedResponse;
        }

        public async Task<ServiceModel> VoteForServiceAsync(long id, VoteRequest voteRequest)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/services/{id}/vote";
            var requestContent = HttpConvertor.GetHttpContent(voteRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<ServiceModel>(content);
            return voteResponse;
        }
    }
}