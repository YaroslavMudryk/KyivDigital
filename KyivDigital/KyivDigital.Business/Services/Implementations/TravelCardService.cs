using KyivDigital.Business.Helpers;
using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Implementations
{
    public class TravelCardService : ITravelCardService
    {
        private readonly HttpClient _httpClient;
        private readonly IClaimsProvider _claimsProvider;
        public TravelCardService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            _httpClient = httpClient;
            _claimsProvider = claimsProvider;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
        }

        public async Task<TravelCardModel> AddTravelCardAsync(TravelCardModelRequest model)
        {
            string url = "api/v3/card/travel/add";
            var requestContent = HttpConvertor.GetHttpContent(model);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var travelResponse = JsonSerializer.Deserialize<TravelCardModel>(content);
            return travelResponse;
        }

        public async Task<TravelCardModel> ChangeCardLockStateAsync(long id, TravelCardLockRequest travelCardLockRequest)
        {
            string url = $"api/v3/card/travel/{id}/lock";
            var requestContent = HttpConvertor.GetHttpContent(travelCardLockRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var travelResponse = JsonSerializer.Deserialize<TravelCardModel>(content);
            return travelResponse;
        }

        public async Task<BaseResponse> DeleteTravelCardAsync(long id)
        {
            string url = $"api/v3/card/travel/{id}/unlink";
            var response = await _httpClient.DeleteAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var travelResponse = JsonSerializer.Deserialize<BaseResponse>(content);
            return travelResponse;
        }

        public async Task<PaymentResponse> GetCardReplenishmentLinkAsync(long id, QrTravelPaymentRequest qrTravelPaymentRequest)
        {
            string url = $"api/v3/card/travel/{id}/tickets-replenishment";
            var requestContent = HttpConvertor.GetHttpContent(qrTravelPaymentRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var travelResponse = JsonSerializer.Deserialize<PaymentResponse>(content);
            return travelResponse;
        }

        public async Task<GooglePayDataResponse> GetMonthlyGooglePayDataAsync(long id, MonthlyPaymentRequest monthlyPaymentRequest)
        {
            string url = $"api/v3/card/travel/{id}/monthly-products?dry_run_google=1";
            var requestContent = HttpConvertor.GetHttpContent(monthlyPaymentRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var travelResponse = JsonSerializer.Deserialize<GooglePayDataResponse>(content);
            return travelResponse;
        }

        public async Task<MonthlyProductsResponse> GetMonthlyProductsAsync(long id)
        {
            string url = $"api/v3/card/travel/{id}/monthly-products";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var travelResponse = JsonSerializer.Deserialize<MonthlyProductsResponse>(content);
            return travelResponse;
        }

        public async Task<TravelCardReplenishResponse> GetReplenishmentTravelCardDataAsync(long id)
        {
            string url = $"api/v3/card/travel/{id}/tickets-replenishment";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var travelResponse = JsonSerializer.Deserialize<TravelCardReplenishResponse>(content);
            return travelResponse;
        }

        public async Task<GooglePayDataResponse> GetTicketGooglePayDataAsync(long id, QrTravelPaymentRequest qrTravelPaymentRequest)
        {
            string url = $"api/v3/card/travel/{id}/tickets-replenishment";
            var requestContent = HttpConvertor.GetHttpContent(qrTravelPaymentRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var travelResponse = JsonSerializer.Deserialize<GooglePayDataResponse>(content);
            return travelResponse;
        }

        public async Task<TicketPriceList> GetTicketPriceListAsync(long id)
        {
            string url = $"api/v3/card/travel/{id}/tickets";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var travelResponse = JsonSerializer.Deserialize<TicketPriceList>(content);
            return travelResponse;
        }

        public async Task<TravelCardModel> GetTravelCardAsync(long id)
        {
            string url = $"api/v3/card/travel/{id}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var travelResponse = JsonSerializer.Deserialize<TravelCardModel>(content);
            return travelResponse;
        }

        public async Task<TravelCardFeedResponse> GetTravelCardFeedAsync(long id)
        {
            string url = $"api/v3/card/travel/{id}/feed";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var travelResponse = JsonSerializer.Deserialize<TravelCardFeedResponse>(content);
            return travelResponse;
        }

        public async Task<TravelCardHistoryResponse> GetTravelCardHistoryAsync(long id)
        {
            string url = $"api/v3/card/travel/{id}/history";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var travelResponse = JsonSerializer.Deserialize<TravelCardHistoryResponse>(content);
            return travelResponse;
        }

        public async Task<TravelCardFeedPagedResponse> GetTravelCardPagedFeedAsync(long id, int page, int per_page)
        {
            string url = $"api/v3/card/travel/{id}/feed?page={page}&per_page={per_page}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var travelResponse = JsonSerializer.Deserialize<TravelCardFeedPagedResponse>(content);
            return travelResponse;
        }

        public async Task<TravelCardsListResponse> GetTravelCardsAsync()
        {
            string url = "api/v3/card/travel";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var travelResponse = JsonSerializer.Deserialize<TravelCardsListResponse>(content);
            return travelResponse;
        }

        public async Task<WalletReplenishResponse> GetWalletReplenishmentDataAsync(long id)
        {
            string url = $"api/v3/card/travel/{id}/wallet-replenishment";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var travelResponse = JsonSerializer.Deserialize<WalletReplenishResponse>(content);
            return travelResponse;
        }

        public async Task<GooglePayDataResponse> GetWalletReplenishmentGooglePayDataAsync(long id, WalletReplenishRequest walletReplenishRequest)
        {
            string url = $"api/v3/card/travel/{id}/wallet-replenishment?dry_run_google=1";
            var requestContent = HttpConvertor.GetHttpContent(walletReplenishRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var travelResponse = JsonSerializer.Deserialize<GooglePayDataResponse>(content);
            return travelResponse;
        }

        public async Task<PaymentResponse> MakeMonthlyProductsPaymentAsync(long id, MonthlyPaymentRequest monthlyPaymentRequest)
        {
            string url = $"api/v3/card/travel/{id}/monthly-products";
            var requestContent = HttpConvertor.GetHttpContent(monthlyPaymentRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var travelResponse = JsonSerializer.Deserialize<PaymentResponse>(content);
            return travelResponse;
        }

        public async Task<BaseResponse> MakeWalletEticketsPaymentAsync(long id, WalletEticketsPaymentRequest walletEticketsPaymentRequest)
        {
            string url = $"api/v3/card/travel/{id}/wallet-purchase";
            var requestContent = HttpConvertor.GetHttpContent(walletEticketsPaymentRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var travelResponse = JsonSerializer.Deserialize<BaseResponse>(content);
            return travelResponse;
        }

        public async Task<PaymentResponse> MakeWalletReplenishmentPaymentAsync(long id, WalletReplenishRequest walletReplenishRequest)
        {
            string url = $"api/v3/card/travel/{id}/wallet-replenishment";
            var requestContent = HttpConvertor.GetHttpContent(walletReplenishRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var travelResponse = JsonSerializer.Deserialize<PaymentResponse>(content);
            return travelResponse;
        }

        public async Task<TravelCardModel> ReplaceCardAsync(long id, TravelCardReplaceModel travelCardReplaceModel)
        {
            string url = $"api/v3/card/travel/{id}/replace";
            var requestContent = HttpConvertor.GetHttpContent(travelCardReplaceModel);
            var response = await _httpClient.PutAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var travelResponse = JsonSerializer.Deserialize<TravelCardModel>(content);
            return travelResponse;
        }

        public async Task<TravelCardModel> UpdateCardAsync(long id, TravelCardUpdateRequest travelCardUpdateRequest)
        {
            string url = $"api/v3/card/travel/{id}";
            var requestContent = HttpConvertor.GetHttpContent(travelCardUpdateRequest);
            var response = await _httpClient.PutAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var travelResponse = JsonSerializer.Deserialize<TravelCardModel>(content);
            return travelResponse;
        }
    }
}