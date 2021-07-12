using KyivDigital.Business.Models;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Interfaces
{
    public interface IEvacuationService
    {
        Task<CheckEvacuationCarResponse> CheckEvacuatedCarAsync(EvacuationCarRequest evacuationCarRequest);
        Task<BaseResponse> ConfirmEvacuationCarAsync(long id);
        Task<GetEvacuationCarResponse> GetEvacuatedCarsAsync();
        Task<GooglePayDataResponse> GetEvacuationGooglePayDataAsync(long id, EvacuationPaymentRequest evacuationPaymentRequest);
        Task<GetEvacuationPaymentResponse> GetEvacuationPaymentAsync(long id);
        Task<EvacuationStatus> GetEvacuationStatusAsync(long id);
        Task<GetEvacuationPaymentResponse> GetEvacuationSurchargeAsync(long id);
        Task<GooglePayDataResponse> GetEvacuationSurchargeGooglePayDataAsync(long id, EvacuationPaymentRequest evacuationPaymentRequest);
        Task<PaymentResponse> MakeEvacuationPaymentAsync(long id, EvacuationPaymentRequest evacuationPaymentRequest);
        Task<PaymentResponse> MakeEvacuationSurchargePaymentAsync(long id, EvacuationPaymentRequest evacuationPaymentRequest);
        //Task<BaseResponse> SendDriversLicenseAsync(long id, @Part MultipartBody.Part part, @Part MultipartBody.Part part2);
        //Task<BaseResponse> SendRegistrationCertificateAsync(long id, @PartAsync("usual_format") RequestBody requestBody, @PartAsync("number") RequestBody requestBody2, @Part MultipartBody.Part part, @Part MultipartBody.Part part2);
    }
}