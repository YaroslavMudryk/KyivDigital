using System.Collections.Generic;
using System.Security.Claims;
namespace KyivDigital.Business.Services.Interfaces
{
    public interface IClaimsProvider
    {
        string GetAccessToken();
        Claim GetClaimByType(string type);
        string GetValueByType(string type);
        Claim GetClaimByValue(string value);
        string GetTypeByValue(string value);
        void UpdateClaim(Claim claim);
        void UpdateClaims(List<Claim> claim);
    }
}