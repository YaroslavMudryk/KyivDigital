using System.Threading.Tasks;
using KyivDigital.Business.Models;
namespace KyivDigital.Business.Services.Interfaces
{
    public interface IQrService
    {
        Task<QRCodeModel> ChangeQRCodeShareStatusAsync(long id, QRCodeShareModel qRCodeShareModel);
        Task<QRCodeModel> ChangeQRCodeUsedStatusAsync(long id);
        Task<QRCodeModel> ChangeQRCodeUsedStatusAsync(long id, QRCodeUsedModel qRCodeUsedModel);
        Task<QRCodesUsedResponse> ChangeQRCodesUsedMultipleStatusAsync(QRCodeUsedList qRCodeUsedList);
        Task<Response<QRCodesUsedResponse>> ChangeQRCodesUsedMultipleStatusWithResponseAsync(QRCodeUsedList qRCodeUsedList);
        Task<GooglePayDataResponse> GetQRCodeGooglePayDataAsync(QrTravelPaymentRequest qrTravelPaymentRequest);
        Task<PaymentResponse> GetQRCodePurchaseLinkAsync(QrTravelPaymentRequest qrTravelPaymentRequest);
        Task<QRTicketData> GetQrTicketDataAsync();
        Task<QRCodesResponse> GetUserQRCodesAsync();
    }
}