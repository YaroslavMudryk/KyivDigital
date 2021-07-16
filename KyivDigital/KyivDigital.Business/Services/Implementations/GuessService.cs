using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using KyivDigital.Business.WebHandlers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Implementations
{
    public class GuessService : IGuessService
    {
        private readonly KyivDigitalRequest _kyivDigitalRequest;
        public GuessService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            var token = claimsProvider.GetAccessToken();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _kyivDigitalRequest = new KyivDigitalRequest(httpClient);
        }

        public async Task<AoAddressResponse> GetHousesAsync(string streetId, string house)
        {
            string url = $"api/v3/guess/address/ao?street={streetId}&search={house}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<AoAddressResponse>(content);
            return feedResponse;
        }

        public async Task<PremiseAddressResponse> GetFlatsAsync(string houseId, string premise)
        {
            string url = $"api/v3/guess/address/premise?ao={houseId}&search={premise}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<PremiseAddressResponse>(content);
            return feedResponse;
        }

        public async Task<StreetAddressResponse> GetStreetsAsync(string street)
        {
            string url = $"api/v3/guess/address/street?search={street}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<StreetAddressResponse>(content);
            return feedResponse;
        }
    }
}