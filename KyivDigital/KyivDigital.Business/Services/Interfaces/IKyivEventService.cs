using KyivDigital.Business.Models;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Interfaces
{
    public interface IKyivEventService
    {
        Task<EventModel> GetEventByIdAsync(long id);

        Task<EventsResponse> GetEventsAsync(long category, string type, int page, double lat, double lng);

        Task<EventModel> LikeEventAsync(long id, LikeRequest likeRequest);
    }
}