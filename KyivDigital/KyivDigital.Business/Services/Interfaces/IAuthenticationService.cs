using KyivDigital.Business.Models;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> LoginAsync(LoginPhoneRequest login);
        Task<TokenResponse> VerifyCodeAsync(LoginPhoneRequest login);
        Task<bool> AuthAsync(Profile profile, string accessToken);
        Task<LoginVerifyResponse> UpdateTokenAsync(LoginPhoneRequest loginPhoneRequest);
        Task<BaseResponse> LogoutAsync();
    }
}