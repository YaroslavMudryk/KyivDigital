using KyivDigital.Business.Helpers;
using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Implementations
{
    public class KyivEventService : IKyivEventService
    {
        private readonly HttpClient _httpClient;
        private readonly IClaimsProvider _claimsProvider;
        public KyivEventService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            _httpClient = httpClient;
            _claimsProvider = claimsProvider;
        }

        public async Task<EventModel> GetEventByIdAsync(long id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/kyiv-events/{id}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<EventModel>(content);
            return voteResponse;
        }

        public async Task<EventsResponse> GetEventsAsync(long category, string type, int page, double lat, double lng)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/kyiv-events?category={category}&type={type}&page={page}&lat={lat}&lng={lng}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<EventsResponse>(content);
            return voteResponse;
        }

        public async Task<EventModel> LikeEventAsync(long id, LikeRequest likeRequest)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/kyiv-events/{id}/like";
            var requestContent = HttpConvertor.GetHttpContent(likeRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<EventModel>(content);
            return voteResponse;
        }
    }
}