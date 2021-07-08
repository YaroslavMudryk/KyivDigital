using KyivDigital.Business.Models;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<Profile> GetUserProfileAsync();
        Task<Profile> GetUserProfileAsync(string accessToken);
    }
}