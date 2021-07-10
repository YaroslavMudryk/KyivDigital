using KyivDigital.Business.Helpers;
using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace KyivDigital.Business.Services.Implementations
{
    public class FaqService : IFaqService
    {
        private readonly HttpClient _httpClient;
        private readonly IClaimsProvider _claimsProvider;
        public FaqService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            _httpClient = httpClient;
            _claimsProvider = claimsProvider;
        }

        public async Task<CategotiesFaqResponse> GetCategoriesFaqAsync(string query, int with_top)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = "api/v3/faq";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<CategotiesFaqResponse>(content);
            return feedResponse;
        }

        public async Task<FaqDetailResponse> GetFaqDetailAsync(long id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/faq/{id}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<FaqDetailResponse>(content);
            return feedResponse;
        }

        public async Task<BaseResponse> VoteForFaqAsync(long id, RateFaqRequest rateFaqRequest)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/faq/{id}/vote";
            var requestContent = HttpConvertor.GetHttpContent(rateFaqRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<BaseResponse>(content);
            return feedResponse;
        }
    }
}