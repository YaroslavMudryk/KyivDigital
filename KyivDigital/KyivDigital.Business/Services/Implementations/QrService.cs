using KyivDigital.Business.Helpers;
using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Implementations
{
    public class QrService : IQrService
    {
        private readonly HttpClient _httpClient;
        private readonly IClaimsProvider _claimsProvider;
        public QrService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            _httpClient = httpClient;
            _claimsProvider = claimsProvider;
        }

        public async Task<QRCodeModel> ChangeQRCodeShareStatusAsync(long id, QRCodeShareModel qRCodeShareModel)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/qr/{id}/shared";
            var requestContent = HttpConvertor.GetHttpContent(qRCodeShareModel);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var qrCodeResponse = JsonSerializer.Deserialize<QRCodeModel>(content);
            return qrCodeResponse;
        }

        public async Task<QRCodesUsedResponse> ChangeQRCodesUsedMultipleStatusAsync(QRCodeUsedList qRCodeUsedList)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = "api/v3/qr/used-multiple";
            var requestContent = HttpConvertor.GetHttpContent(qRCodeUsedList);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var qrCodeResponse = JsonSerializer.Deserialize<QRCodesUsedResponse>(content);
            return qrCodeResponse;
        }

        public async Task<Response<QRCodesUsedResponse>> ChangeQRCodesUsedMultipleStatusWithResponseAsync(QRCodeUsedList qRCodeUsedList)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = "api/v3/qr/used-multiple";
            var requestContent = HttpConvertor.GetHttpContent(qRCodeUsedList);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var qrCodeResponse = JsonSerializer.Deserialize< Response<QRCodesUsedResponse>>(content);
            return qrCodeResponse;
        }

        public async Task<QRCodeModel> ChangeQRCodeUsedStatusAsync(long id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/qr/{id}/used";
            var response = await _httpClient.PostAsync(url, null);
            var content = await response.Content.ReadAsStringAsync();
            var qrCodeResponse = JsonSerializer.Deserialize<QRCodeModel>(content);
            return qrCodeResponse;
        }

        public async Task<QRCodeModel> ChangeQRCodeUsedStatusAsync(long id, QRCodeUsedModel qRCodeUsedModel)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/qr/{id}/used";
            var requestContent = HttpConvertor.GetHttpContent(qRCodeUsedModel);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var qrCodeResponse = JsonSerializer.Deserialize<QRCodeModel>(content);
            return qrCodeResponse;
        }

        public async Task<GooglePayDataResponse> GetQRCodeGooglePayDataAsync(QrTravelPaymentRequest qrTravelPaymentRequest)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = "api/v3/qr/purchase";
            var requestContent = HttpConvertor.GetHttpContent(qrTravelPaymentRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var qrCodeResponse = JsonSerializer.Deserialize<GooglePayDataResponse>(content);
            return qrCodeResponse;
        }

        public async Task<PaymentResponse> GetQRCodePurchaseLinkAsync(QrTravelPaymentRequest qrTravelPaymentRequest)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = "api/v3/qr/purchase";
            var requestContent = HttpConvertor.GetHttpContent(qrTravelPaymentRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var qrCodeResponse = JsonSerializer.Deserialize<PaymentResponse>(content);
            return qrCodeResponse;
        }

        public async Task<QRTicketData> GetQrTicketDataAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = "api/v3/qr/purchase";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var qrCodeResponse = JsonSerializer.Deserialize<QRTicketData>(content);
            return qrCodeResponse;
        }

        public async Task<QRCodesResponse> GetUserQRCodesAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = "api/v3/qr";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var qrCodeResponse = JsonSerializer.Deserialize<QRCodesResponse>(content);
            return qrCodeResponse;
        }
    }
}