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
    public class FeedService : IFeedService
    {
        private readonly KyivDigitalRequest _kyivDigitalRequest;
        public FeedService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            var token = claimsProvider.GetAccessToken();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _kyivDigitalRequest = new KyivDigitalRequest(httpClient);
        }

        public async Task<FeedEvacuationResponse> GetEvacuationFeedAsync(string id)
        {
            string url = $"api/v3/feed/{id}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<FeedEvacuationResponse>(content);
            return feedResponse;
        }

        public async Task<ExpiringQRsResponse> GetExpiringQRsFeedAsync(string id)
        {
            string url = $"api/v3/feed/{id}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<ExpiringQRsResponse>(content);
            return feedResponse;
        }

        public async Task<FeedFineResponse> GetFineFeedAsync(string id)
        {
            string url = $"api/v3/feed/{id}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<FeedFineResponse>(content);
            return feedResponse;
        }

        public async Task<FeedInfoModel> GetInfoFeedAsync(string id)
        {
            string url = $"api/v3/feed/{id}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<FeedInfoModel>(content);
            return feedResponse;
        }

        public async Task<FeedResponse> GetLastFeedAsync()
        {
            string url = "api/v3/feed?per_page=1";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<FeedResponse>(content);
            return feedResponse;
        }

        public async Task<PagedFeedResponse> GetPagedUserHistoryAsync(int page = default, int count = default)
        {
            string url = $"api/v3/feed?page={page}&per_page={count}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<PagedFeedResponse>(content);
            return feedResponse;
        }

        public async Task<FeedParkingResponse> GetParkingFeedAsync(string id)
        {
            string url = $"api/v3/feed/{id}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<FeedParkingResponse>(content);
            return feedResponse;
        }

        public async Task<FeedParkingHourlyResponse> GetParkingHourlyFeedAsync(string id)
        {
            string url = $"api/v3/feed/{id}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<FeedParkingHourlyResponse>(content);
            return feedResponse;
        }

        public async Task<QRPurchasedFeedResponse> GetQRPurchasedFeedAsync(string id)
        {
            string url = $"api/v3/feed/{id}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<QRPurchasedFeedResponse>(content);
            return feedResponse;
        }

        public async Task<QRCodeModel> GetQRUsedFeedAsync(string id)
        {
            string url = $"api/v3/feed/{id}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<QRCodeModel>(content);
            return feedResponse;
        }

        public async Task<TravelCardFeedResponse> GetTravelCardReplenishFeed(string id)
        {
            string url = $"api/v3/feed/{id}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<TravelCardFeedResponse>(content);
            return feedResponse;
        }

        public async Task<FeedResponse> GetUserHistoryAsync(string id)
        {
            string url = $"api/v3/feed/{id}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<FeedResponse>(content);
            return feedResponse;
        }

        public async Task<FeedCongratulationResponse> GetWelcomeFeedAsync(string id)
        {
            string url = $"api/v3/feed/{id}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<FeedCongratulationResponse>(content);
            return feedResponse;
        }

        public async Task<BaseResponse> VoteForFeedAsync(string id, RateModel rateModel)
        {
            string url = $"api/v3/feed/{id}/vote";
            var response = await _kyivDigitalRequest.PostAsync(url, rateModel);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<BaseResponse>(content);
            return voteResponse;
        }
    }
}