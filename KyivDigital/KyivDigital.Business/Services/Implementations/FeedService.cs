using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using KyivDigital.Business.Storage;
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
        private readonly IClaimsProvider _claimsProvider;
        private readonly IStorageService<PagedFeedResponse> _pagedFeedStorageService;
        public FeedService(HttpClient httpClient, IClaimsProvider claimsProvider, IStorageService<PagedFeedResponse> pagedFeedStorageService)
        {
            _claimsProvider = claimsProvider;
            var token = claimsProvider.GetAccessToken();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _kyivDigitalRequest = new KyivDigitalRequest(httpClient);
            _pagedFeedStorageService = pagedFeedStorageService;
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

        public async Task<PagedFeedResponse> GetPagedUserHistoryAsync(int page, int count)
        {
            string url = $"api/v3/feed?page={page}&per_page={count}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<PagedFeedResponse>(content);
            return feedResponse;
        }

        public async Task<PagedFeedResponse> GetPagedUserHistoryAsync()
        {
            string userId = _claimsProvider.GetUserId();
            var feedFromCache = _pagedFeedStorageService.Get(userId);
            if (feedFromCache == null || feedFromCache.Feed == null)
            {
                var feedResponse = await GetPagedUserHistoryAsync(1, 20);
                _pagedFeedStorageService.Post(userId, feedResponse);
                return feedResponse;
            }
            else
            {
                if (isAllFeedDownloaded(feedFromCache))
                    return feedFromCache;
                int currentPage = getCurrentPage(feedFromCache);
                int count = getCountForCurrentPage(feedFromCache);
                var feedResponse = await GetPagedUserHistoryAsync(currentPage, count);
                var feeds = feedFromCache.Feed.Data;
                feedFromCache.Feed.Data.AddRange(feeds);
                feedFromCache.Feed.Meta.Pagination = setNewPagination(feedFromCache, feedResponse);
                _pagedFeedStorageService.Post(userId, feedFromCache);
                return feedFromCache;
            }
        }

        private Pagination setNewPagination(PagedFeedResponse feedFromCache, PagedFeedResponse feedResponse)
        {
            return new Pagination
            {
                Count = feedResponse.Feed.Meta.Pagination.Count + feedFromCache.Feed.Meta.Pagination.Count,
                CurrentPage = feedResponse.Feed.Meta.Pagination.CurrentPage,
                PerPage = feedResponse.Feed.Meta.Pagination.PerPage,
                Total = feedResponse.Feed.Meta.Pagination.Total,
                TotalPages = feedResponse.Feed.Meta.Pagination.TotalPages
            };
        }

        private int getCurrentPage(PagedFeedResponse pagedFeed)
        {
            var totalPage = pagedFeed.Feed.Meta.Pagination.TotalPages; // 4
            var currentPage = pagedFeed.Feed.Meta.Pagination.CurrentPage; // 2
            var nextPage = currentPage + 1; // 3
            if (nextPage > totalPage)
                return currentPage;
            return nextPage; // 3
        }

        private int getCountForCurrentPage(PagedFeedResponse pagedFeed)
        {
            var totalCountFeed = pagedFeed.Feed.Meta.Pagination.Total;// 69
            var currentCount = pagedFeed.Feed.Data.Count; // 80
            var diff = totalCountFeed - currentCount; //50
            if (diff > 20 || diff < 1)
                return 20; //20
            return diff;
        }

        private bool isAllFeedDownloaded(PagedFeedResponse pagedFeed)
        {
            var totalFeedCount = pagedFeed.Feed.Meta.Pagination.Total;
            var currentFeedCount = pagedFeed.Feed.Data.Count;
            return totalFeedCount == currentFeedCount;
        }
    }
}