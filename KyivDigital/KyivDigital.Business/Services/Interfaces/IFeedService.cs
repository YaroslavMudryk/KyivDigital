using KyivDigital.Business.Models;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Interfaces
{
    public interface IFeedService
    {
        Task<PagedFeedResponse> GetPagedUserHistoryAsync(int page = default, int count = default);
    }
}