using KyivDigital.Business.Models;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Interfaces
{
    public interface ITransportService
    {
        Task<SavedAndSearchedRoutesResponse> GetSavedAndSearchedRoutesAsync();
        Task<TransportRouteDetailsResponse> GetTransportRouteDetailsAsync(long id, int save_search);
        Task<TransportStopDetailsResponse> GetTransportStopAsync(long id, int save_search);
        Task<TransportStopsResponse> LoadTransportStopsAsync();
        Task<SavedRoutesResponse> SaveTransportRouteAsync(long id, TransportRouteSaveStateRequest transportRouteSaveStateRequest);
        Task<TransportRoutesResponse> SearchRoutesAndStopsAsync(string query);
    }
}