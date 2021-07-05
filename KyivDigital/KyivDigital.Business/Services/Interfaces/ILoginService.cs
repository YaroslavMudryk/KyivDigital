using KyivDigital.Business.Models;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResponse> LoginAsync(LoginPhoneRequest login);
        Task<TokenResponse> VerifyCodeAsync(LoginPhoneRequest login);
    }
}