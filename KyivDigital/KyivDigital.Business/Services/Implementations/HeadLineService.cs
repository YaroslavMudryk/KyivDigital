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
        private readonly KyivDigitalRequest _kyivDigitalRequest;
        public HeadLineService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            var token = claimsProvider.GetAccessToken();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _kyivDigitalRequest = new KyivDigitalRequest(httpClient);
        }

        public async Task<HeadLineModel> GetHeadLineAsync()
        {
            var response = await _kyivDigitalRequest.GetAsync("api/v3/headline");
            _kyivDigitalRequest.CheckAuthResponse(response);
            var headLineResponse = JsonSerializer.Deserialize<HeadLineModel>(await response.Content.ReadAsStringAsync());
            return headLineResponse;
        }
    }
}