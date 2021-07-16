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
    public class FaqService : IFaqService
    {
        private readonly KyivDigitalRequest _kyivDigitalRequest;
        public FaqService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            var token = claimsProvider.GetAccessToken();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _kyivDigitalRequest = new KyivDigitalRequest(httpClient);
        }

        public async Task<CategotiesFaqResponse> GetCategoriesFaqAsync(string query, int with_top)
        {
            string url = "api/v3/faq";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<CategotiesFaqResponse>(content);
            return feedResponse;
        }

        public async Task<FaqDetailResponse> GetFaqDetailAsync(long id)
        {
            string url = $"api/v3/faq/{id}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<FaqDetailResponse>(content);
            return feedResponse;
        }

        public async Task<BaseResponse> VoteForFaqAsync(long id, RateFaqRequest rateFaqRequest)
        {
            string url = $"api/v3/faq/{id}/vote";
            var response = await _kyivDigitalRequest.PostAsync(url, rateFaqRequest);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<BaseResponse>(content);
            return feedResponse;
        }
    }
}