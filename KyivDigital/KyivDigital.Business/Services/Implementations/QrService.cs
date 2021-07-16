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
    public class QrService : IQrService
    {
        private readonly KyivDigitalRequest _kyivDigitalRequest;
        public QrService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            var token = claimsProvider.GetAccessToken();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _kyivDigitalRequest = new KyivDigitalRequest(httpClient);
        }

        public async Task<QRCodeModel> ChangeQRCodeShareStatusAsync(long id, QRCodeShareModel qRCodeShareModel)
        {
            string url = $"api/v3/qr/{id}/shared";
            var response = await _kyivDigitalRequest.PostAsync(url, qRCodeShareModel);
            var content = await response.Content.ReadAsStringAsync();
            var qrCodeResponse = JsonSerializer.Deserialize<QRCodeModel>(content);
            return qrCodeResponse;
        }

        public async Task<QRCodesUsedResponse> ChangeQRCodesUsedMultipleStatusAsync(QRCodeUsedList qRCodeUsedList)
        {
            string url = "api/v3/qr/used-multiple";
            var response = await _kyivDigitalRequest.PostAsync(url, qRCodeUsedList);
            var content = await response.Content.ReadAsStringAsync();
            var qrCodeResponse = JsonSerializer.Deserialize<QRCodesUsedResponse>(content);
            return qrCodeResponse;
        }

        public async Task<Response<QRCodesUsedResponse>> ChangeQRCodesUsedMultipleStatusWithResponseAsync(QRCodeUsedList qRCodeUsedList)
        {
            string url = "api/v3/qr/used-multiple";
            var response = await _kyivDigitalRequest.PostAsync(url, qRCodeUsedList);
            var content = await response.Content.ReadAsStringAsync();
            var qrCodeResponse = JsonSerializer.Deserialize< Response<QRCodesUsedResponse>>(content);
            return qrCodeResponse;
        }

        public async Task<QRCodeModel> ChangeQRCodeUsedStatusAsync(long id)
        {
            string url = $"api/v3/qr/{id}/used";
            var response = await _kyivDigitalRequest.PostAsync(url, null);
            var content = await response.Content.ReadAsStringAsync();
            var qrCodeResponse = JsonSerializer.Deserialize<QRCodeModel>(content);
            return qrCodeResponse;
        }

        public async Task<QRCodeModel> ChangeQRCodeUsedStatusAsync(long id, QRCodeUsedModel qRCodeUsedModel)
        {
            string url = $"api/v3/qr/{id}/used";
            var response = await _kyivDigitalRequest.PostAsync(url, qRCodeUsedModel);
            var content = await response.Content.ReadAsStringAsync();
            var qrCodeResponse = JsonSerializer.Deserialize<QRCodeModel>(content);
            return qrCodeResponse;
        }

        public async Task<GooglePayDataResponse> GetQRCodeGooglePayDataAsync(QrTravelPaymentRequest qrTravelPaymentRequest)
        {
            string url = "api/v3/qr/purchase";
            var response = await _kyivDigitalRequest.PostAsync(url, qrTravelPaymentRequest);
            var content = await response.Content.ReadAsStringAsync();
            var qrCodeResponse = JsonSerializer.Deserialize<GooglePayDataResponse>(content);
            return qrCodeResponse;
        }

        public async Task<PaymentResponse> GetQRCodePurchaseLinkAsync(QrTravelPaymentRequest qrTravelPaymentRequest)
        {
            string url = "api/v3/qr/purchase";
            var response = await _kyivDigitalRequest.PostAsync(url, qrTravelPaymentRequest);
            var content = await response.Content.ReadAsStringAsync();
            var qrCodeResponse = JsonSerializer.Deserialize<PaymentResponse>(content);
            return qrCodeResponse;
        }

        public async Task<QRTicketData> GetQrTicketDataAsync()
        {
            string url = "api/v3/qr/purchase";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var qrCodeResponse = JsonSerializer.Deserialize<QRTicketData>(content);
            return qrCodeResponse;
        }

        public async Task<QRCodesResponse> GetUserQRCodesAsync()
        {
            string url = "api/v3/qr";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var qrCodeResponse = JsonSerializer.Deserialize<QRCodesResponse>(content);
            return qrCodeResponse;
        }
    }
}