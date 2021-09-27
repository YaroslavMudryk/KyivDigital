using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using KyivDigital.Business.WebHandlers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace KyivDigital.Business.Services.Implementations
{
    public class TransportService : ITransportService
    {
        private readonly KyivDigitalRequest _kyivDigitalRequest;
        public TransportService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            var token = claimsProvider.GetAccessToken();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _kyivDigitalRequest = new KyivDigitalRequest(httpClient);
        }

        public async Task<SavedAndSearchedRoutesResponse> GetSavedAndSearchedRoutesAsync()
        {
            var url = "api/v4/transport/data";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var transportResponse = JsonSerializer.Deserialize<SavedAndSearchedRoutesResponse>(content);
            return transportResponse;
        }

        public async Task<TransportRoutesMapViewModel> GetTransportRouteDetailsAsync(long id, int saveSearch)
        {
            var url = $"api/v4/transport/routes/{id}?save_search={saveSearch}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var transportResponse = JsonSerializer.Deserialize<TransportRoutesMapViewModel>(content);
            return transportResponse;
        }

        public async Task<TransportStopDetailsResponse> GetTransportStopAsync(long id, int saveSearch)
        {
            var url = $"api/v4/transport/stops/{id}?save_search={saveSearch}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var transportResponse = JsonSerializer.Deserialize<TransportStopDetailsResponse>(content);
            return transportResponse;
        }

        public async Task<TransportStopsResponse> LoadTransportStopsAsync()
        {
            var url = "api/v4/transport/stops";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var transportResponse = JsonSerializer.Deserialize<TransportStopsResponse>(content);
            return transportResponse;
        }

        public async Task<SavedRoutesResponse> SaveTransportRouteAsync(long id, TransportRouteSaveStateRequest transportRouteSaveStateRequest)
        {
            var url = $"api/v4/transport/routes/{id}/save";
            var response = await _kyivDigitalRequest.PostAsync(url, transportRouteSaveStateRequest);
            var content = await response.Content.ReadAsStringAsync();
            var transportResponse = JsonSerializer.Deserialize<SavedRoutesResponse>(content);
            return transportResponse;
        }

        public async Task<TransportRoutesResponse> SearchRoutesAndStopsAsync(string query)
        {
            var url = $"api/v4/transport/search?query={query}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var transportResponse = JsonSerializer.Deserialize<TransportRoutesResponse>(content);
            return transportResponse;
        }
    }
}
