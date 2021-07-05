using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Implementations
{
    public class HeadLineService : IHeadLineService
    {
        private readonly HttpClient _httpClient;
        private readonly IClaimsProvider _claimsProvider;

        public HeadLineService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            _httpClient = httpClient;
            _claimsProvider = claimsProvider;
        }

        public async Task<HeadLineModel> GetHeadLineAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            var response = await _httpClient.GetAsync("api/v3/headline");
            var headLineResponse = JsonSerializer.Deserialize<HeadLineModel>(await response.Content.ReadAsStringAsync());
            return headLineResponse;
        }
    }
}