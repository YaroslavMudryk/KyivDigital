using KyivDigital.Business.Helpers;
using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Implementations
{
    public class FeedService : IFeedService
    {
        private readonly HttpClient _httpClient;
        private readonly IClaimsProvider _claimsProvider;
        public FeedService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            _httpClient = httpClient;
            _claimsProvider = claimsProvider;
        }

        public async Task<FeedEvacuationResponse> GetEvacuationFeedAsync(string id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/feed/{id}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<FeedEvacuationResponse>(content);
            return feedResponse;
        }

        public async Task<ExpiringQRsResponse> GetExpiringQRsFeedAsync(string id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/feed/{id}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<ExpiringQRsResponse>(content);
            return feedResponse;
        }

        public async Task<FeedFineResponse> GetFineFeedAsync(string id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/feed/{id}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<FeedFineResponse>(content);
            return feedResponse;
        }

        public async Task<FeedInfoModel> GetInfoFeedAsync(string id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/feed/{id}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<FeedInfoModel>(content);
            return feedResponse;
        }

        public async Task<PagedFeedResponse> GetPagedUserHistoryAsync(int page = default, int count = default)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = "";
            if (page == default && count == default)
                url = "api/v3/feed";
            else
                url = $"api/v3/feed?page={page}&per_page={count}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<PagedFeedResponse>(content);
            return feedResponse;
        }

        public async Task<FeedParkingResponse> GetParkingFeedAsync(string id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/feed/{id}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<FeedParkingResponse>(content);
            return feedResponse;
        }

        public async Task<FeedParkingHourlyResponse> GetParkingHourlyFeedAsync(string id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/feed/{id}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<FeedParkingHourlyResponse>(content);
            return feedResponse;
        }

        public async Task<QRPurchasedFeedResponse> GetQRPurchasedFeedAsync(string id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/feed/{id}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<QRPurchasedFeedResponse>(content);
            return feedResponse;
        }

        public async Task<QRCodeModel> GetQRUsedFeedAsync(string id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/feed/{id}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<QRCodeModel>(content);
            return feedResponse;
        }

        public async Task<TravelCardFeedResponse> GetTravelCardReplenishFeed(string id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/feed/{id}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<TravelCardFeedResponse>(content);
            return feedResponse;
        }

        public async Task<FeedResponse> GetUserHistoryAsync(string id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/feed/{id}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<FeedResponse>(content);
            return feedResponse;
        }

        public async Task<FeedCongratulationResponse> GetWelcomeFeedAsync(string id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/feed/{id}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<FeedCongratulationResponse>(content);
            return feedResponse;
        }

        public async Task<BaseResponse> VoteForFeedAsync(string id, RateModel rateModel)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/feed/{id}/vote";
            var requestContent = HttpConvertor.GetHttpContent(rateModel);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<BaseResponse>(content);
            return voteResponse;
        }
    }
}