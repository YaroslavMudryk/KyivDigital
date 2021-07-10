using KyivDigital.Business.Models;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Interfaces
{
    public interface IFeedService
    {
        Task<FeedEvacuationResponse> GetEvacuationFeedAsync(string id);

        Task<ExpiringQRsResponse> GetExpiringQRsFeedAsync(string id);

        Task<FeedFineResponse> GetFineFeedAsync(string id);

        Task<FeedInfoModel> GetInfoFeedAsync(string id);

        Task<PagedFeedResponse> GetPagedUserHistoryAsync(int page = default, int count = default);

        Task<FeedParkingResponse> GetParkingFeedAsync(string id);

        Task<FeedParkingHourlyResponse> GetParkingHourlyFeedAsync(string id);

        Task<QRPurchasedFeedResponse> GetQRPurchasedFeedAsync(string id);

        Task<QRCodeModel> GetQRUsedFeedAsync(string id);

        Task<TravelCardFeedResponse> GetTravelCardReplenishFeed(string id);

        Task<FeedResponse> GetUserHistoryAsync(string id);

        Task<FeedCongratulationResponse> GetWelcomeFeedAsync(string id);

        Task<BaseResponse> VoteForFeedAsync(string id, RateModel rateModel);
    }
}