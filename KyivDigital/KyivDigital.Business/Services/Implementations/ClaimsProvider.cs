using KyivDigital.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace KyivDigital.Business.Services.Implementations
{
    public class ClaimsProvider : IClaimsProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClaimsProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetAccessToken()
        {
            var res = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "accessToken");
            if (res != null)
                return res.Value;
            return null;
        }

        public Claim GetClaimByType(string type)
        {
            return _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == type);
        }

        public string GetValueByType(string type)
        {
            var res = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == type);
            if (res != null)
                return res.Value;
            return null;
        }

        public Claim GetClaimByValue(string value)
        {
            return _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Value == value);
        }

        public string GetTypeByValue(string value)
        {
            var res = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Value == value);
            if (res != null)
                return res.Type;
            return null;
        }

        public void UpdateClaim(Claim claim)
        {
            var claimsIdentity = (ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity;
            var oldClaim = claimsIdentity.Claims.FirstOrDefault(p => p.Type == ClaimTypes.UserData);
            if (oldClaim != null)
            {
                claimsIdentity.RemoveClaim(oldClaim);
                claimsIdentity.AddClaim(claim);
                return;
            }
            claimsIdentity.AddClaim(claim);
        }

        public void UpdateClaims(List<Claim> claim)
        {
            throw new System.NotImplementedException();
        }
    }
}
