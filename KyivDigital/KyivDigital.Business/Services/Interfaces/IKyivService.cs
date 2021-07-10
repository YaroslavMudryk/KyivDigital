using KyivDigital.Business.Models;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Interfaces
{
    public interface IKyivService
    {
        Task<ServiceModel> GetServiceInfoAsync(long id);

        Task<ServiceResponse> GetServicesAsync();

        Task<ServiceModel> VoteForServiceAsync(long id, VoteRequest voteRequest);
    }
}