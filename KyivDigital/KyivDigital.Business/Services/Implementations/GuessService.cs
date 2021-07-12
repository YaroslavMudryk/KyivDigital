using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Implementations
{
    public class GuessService : IGuessService
    {
        private readonly HttpClient _httpClient;
        private readonly IClaimsProvider _claimsProvider;
        public GuessService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            _httpClient = httpClient;
            _claimsProvider = claimsProvider;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
        }

        public async Task<AoAddressResponse> GetHousesAsync(string streetId, string house)
        {
            string url = $"api/v3/guess/address/ao?street={streetId}&search={house}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<AoAddressResponse>(content);
            return feedResponse;
        }

        public async Task<PremiseAddressResponse> GetFlatsAsync(string houseId, string premise)
        {
            string url = $"api/v3/guess/address/premise?ao={houseId}&search={premise}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<PremiseAddressResponse>(content);
            return feedResponse;
        }

        public async Task<StreetAddressResponse> GetStreetsAsync(string street)
        {
            string url = $"api/v3/guess/address/street?search={street}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<StreetAddressResponse>(content);
            return feedResponse;
        }
    }
}