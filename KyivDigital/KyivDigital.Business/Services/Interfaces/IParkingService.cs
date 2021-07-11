using KyivDigital.Business.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Interfaces
{
    public interface IParkingService
    {
        Task<ParkingBayResponse> GetParkingBayAsync();
        Task<GooglePayDataResponse> GetParkingGooglePayDataAsync(ParkingPaymentRequest parkingPaymentRequest);
        Task<ParkingSubscriptionsResponse> GetParkingSubscriptionsAsync(int page);
        Task<ParkingSubscriptionsResponse> GetParkingSubscriptionsArchiveAsync(int page);
        Task<ParkingZonesResponse> GetParkingZonesAsync();
        Task<ZonePricesResponse> GetZonePricesAsync();
        Task<PaymentResponse> MakeParkingPaymentAsync(ParkingPaymentRequest parkingPaymentRequest);
    }
}