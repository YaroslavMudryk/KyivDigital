using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using KyivDigital.Business.WebHandlers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Implementations
{
    public class KyivService : IKyivService
    {
        private readonly KyivDigitalRequest _kyivDigitalRequest;
        public KyivService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            var token = claimsProvider.GetAccessToken();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _kyivDigitalRequest = new KyivDigitalRequest(httpClient);
        }

        public async Task<ServiceModel> GetServiceInfoAsync(long id)
        {
            string url = $"api/v3/services/{id}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<ServiceModel>(content);
            return feedResponse;
        }

        public async Task<ServiceResponse> GetServicesAsync()
        {
            string url = "api/v3/services";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<ServiceResponse>(content);
            return feedResponse;
        }

        public async Task<ServiceModel> VoteForServiceAsync(long id, VoteRequest voteRequest)
        {
            string url = $"api/v3/services/{id}/vote";
            var response = await _kyivDigitalRequest.PostAsync(url, voteRequest);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<ServiceModel>(content);
            return voteResponse;
        }
    }
}