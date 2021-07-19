using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using KyivDigital.Business.Storage;
using KyivDigital.Business.WebHandlers;
using System.Linq;
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
                if (IsAllFeedDownloaded(feedFromCache))
                    return feedFromCache;
                var nextPage = GetNextPageForRequest(feedFromCache);
                if (nextPage == -1)
                    return null;
                var feedResponse = await GetPagedUserHistoryAsync(nextPage, 20);
                var feeds = feedResponse.Feed.Data;
                var countOfNewFeed = feedResponse.Feed.Data.Count;
                feedFromCache.Feed.Data.AddRange(feeds);
                feedFromCache.Feed.Data = feedFromCache.Feed.Data.OrderByDescending(x => x.CreatedAt).ToList();
                feedFromCache.Feed.Meta.Pagination.Count += countOfNewFeed;
                feedFromCache.Feed.Meta.Pagination.CurrentPage = nextPage;
                _pagedFeedStorageService.Post(userId, feedFromCache);
                var feedToResponse = feedFromCache.DeepCopy();
                var pag = feedFromCache.Feed.Meta.Pagination;
                var skipCount = GetCountSkip(pag.TotalPages, pag.CurrentPage, pag.Total, pag.Count);
                feedToResponse.Feed.Data = feedToResponse.Feed.Data.Skip(skipCount).ToList();
                return feedToResponse;
            }
        }


        private int GetCountSkip(int totalPages, int currentPage, int totalCount, int currentCount)
        {
            int per_page = 20;
            if (totalPages == currentPage)
            {
                if (totalCount % 20 == 0)
                    return currentCount - 20;
                var notFullCount = totalCount / per_page;
                notFullCount++;
                var diff = (per_page * notFullCount) - totalCount;
                return currentCount - diff;
            }
            return currentCount - 20;
        }

        private int GetNextPageForRequest(PagedFeedResponse pagedFeed)
        {
            const int basic = -1;
            var totalPages = pagedFeed.Feed.Meta.Pagination.TotalPages;
            var currentPage = pagedFeed.Feed.Meta.Pagination.CurrentPage;
            int nextPage = currentPage + 1;
            if (nextPage > totalPages)
            {
                return basic;
            }
            return nextPage;
        }

        private bool IsAllFeedDownloaded(PagedFeedResponse pagedFeed)
        {
            var totalFeedCount = pagedFeed.Feed.Meta.Pagination.Total;
            var currentFeedCount = pagedFeed.Feed.Data.Count;
            return totalFeedCount == currentFeedCount;
        }
    }
}