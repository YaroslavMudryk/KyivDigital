using KyivDigital.Business.Models;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Interfaces
{
    public interface ITravelCardService
    {
        Task<TravelCardModel> AddTravelCardAsync(TravelCardModelRequest model);

        Task<TravelCardModel> ChangeCardLockStateAsync(long id, TravelCardLockRequest travelCardLockRequest);

        Task<BaseResponse> DeleteTravelCardAsync(long id);

        Task<PaymentResponse> GetCardReplenishmentLinkAsync(long id, QrTravelPaymentRequest qrTravelPaymentRequest);

        Task<GooglePayDataResponse> GetMonthlyGooglePayDataAsync(long id, MonthlyPaymentRequest monthlyPaymentRequest);

        Task<MonthlyProductsResponse> GetMonthlyProductsAsync(long id);

        Task<TravelCardReplenishResponse> GetReplenishmentTravelCardDataAsync(long id);

        Task<GooglePayDataResponse> GetTicketGooglePayDataAsync(long id, QrTravelPaymentRequest qrTravelPaymentRequest);

        Task<TicketPriceList> GetTicketPriceListAsync(long id);

        Task<TravelCardModel> GetTravelCardAsync(long id);

        Task<TravelCardFeedResponse> GetTravelCardFeedAsync(long id);

        Task<TravelCardHistoryResponse> GetTravelCardHistoryAsync(long id);

        Task<TravelCardFeedPagedResponse> GetTravelCardPagedFeedAsync(long id, int page, int per_page);

        Task<TravelCardsListResponse> GetTravelCardsAsync();

        Task<WalletReplenishResponse> GetWalletReplenishmentDataAsync(long id);

        Task<GooglePayDataResponse> GetWalletReplenishmentGooglePayDataAsync(long id, WalletReplenishRequest walletReplenishRequest);

        Task<PaymentResponse> MakeMonthlyProductsPaymentAsync(long id, MonthlyPaymentRequest monthlyPaymentRequest);

        Task<BaseResponse> MakeWalletEticketsPaymentAsync(long id, WalletEticketsPaymentRequest walletEticketsPaymentRequest);

        Task<PaymentResponse> MakeWalletReplenishmentPaymentAsync(long id, WalletReplenishRequest walletReplenishRequest);

        Task<TravelCardModel> ReplaceCardAsync(long id, TravelCardReplaceModel travelCardReplaceModel);

        Task<TravelCardModel> UpdateCardAsync(long id, TravelCardUpdateRequest travelCardUpdateRequest);
    }
}