using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
namespace KyivDigital.Business.Services.Interfaces
{
    public interface IClaimsProvider
    {
        string GetAccessToken();
        string GetUserId();
        Claim GetClaimByType(string type);
        string GetValueByType(string type);
        Claim GetClaimByValue(string value);
        string GetTypeByValue(string value);
        void UpdateClaim(Claim claim);
        void UpdateClaims(List<Claim> claim);
        HttpContext HttpContext { get; }
    }
}