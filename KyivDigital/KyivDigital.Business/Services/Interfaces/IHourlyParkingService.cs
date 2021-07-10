using KyivDigital.Business.Models;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Interfaces
{
    public interface IHourlyParkingService
    {
        Task<HourlyParkingListResponse> GetHourlyParkingListAsync();

        Task<HourlyParkingListResponse> GetHourlyParkingNewAsync(double lat, double lng);

        Task<ActiveSession> StartHourlyParkingAsync(HourlyParkingStartRequest hourlyParkingStartRequest);
    }
}