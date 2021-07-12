using System.Threading.Tasks;
using KyivDigital.Business.Models;
namespace KyivDigital.Business.Services.Interfaces
{
    public interface IPenaltiesService
    {
        Task<FineCheckCarResponse> CheckFineCarAsync(FineCheckCarRequest fineCheckCarRequest);
        Task<GooglePayDataResponse> GetFineGooglePayDataAsync(string id, FinePaymentRequest finePaymentRequest);
        Task<FinePaymentResponse> GetFinePaymentDetailsByIdAsync(string id);
        Task<FinesPaymentFeedResponse> GetFinePaymentsFeedAsync(int page = 1);
        Task<FinesResponse> GetFinesAsync();
        Task<FinesRegionsResponse> GetFinesRegionsAsync();
        Task<GooglePayDataResponse> GetRawFineGooglePayDataAsync(FinePaymentRequest finePaymentRequest);
        Task<PaymentResponse> MakeFinePaymentAsync(string id, FinePaymentRequest finePaymentRequest);
        Task<PaymentResponse> MakeRawFinePaymentAsync(FinePaymentRequest finePaymentRequest);
    }
}