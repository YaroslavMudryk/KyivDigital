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
    public class KyivEventService : IKyivEventService
    {
        private readonly KyivDigitalRequest _kyivDigitalRequest;
        public KyivEventService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            var token = claimsProvider.GetAccessToken();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _kyivDigitalRequest = new KyivDigitalRequest(httpClient);
        }

        public async Task<EventModel> GetEventByIdAsync(long id)
        {
            string url = $"api/v3/kyiv-events/{id}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<EventModel>(content);
            return voteResponse;
        }

        public async Task<EventsResponse> GetEventsAsync(long category, string type, int page, double lat, double lng)
        {
            string url = $"api/v3/kyiv-events?category={category}&type={type}&page={page}&lat={lat}&lng={lng}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<EventsResponse>(content);
            return voteResponse;
        }

        public async Task<EventModel> LikeEventAsync(long id, LikeRequest likeRequest)
        {
            string url = $"api/v3/kyiv-events/{id}/like";
            var requestContent = HttpConvertor.GetHttpContent(likeRequest);
            var response = await _kyivDigitalRequest.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<EventModel>(content);
            return voteResponse;
        }
    }
}