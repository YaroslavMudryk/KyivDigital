using KyivDigital.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace KyivDigital.Business.Services.Implementations
{
    public class SessionService : ISessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void ClearSessions()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }

        public T GetSessionValue<T>(string key)
        {
            if (_httpContextAccessor.HttpContext.Session.Keys.Contains(key))
            {
                var tResponse = _httpContextAccessor.HttpContext.Session.GetString(key);
                return (T)Convert.ChangeType(tResponse, typeof(T));
            }
            return default;
        }

        public bool TryRemove(string key)
        {
            if (_httpContextAccessor.HttpContext.Session.Keys.Contains(key))
            {
                _httpContextAccessor.HttpContext.Session.Remove(key);
                return true;
            }
            return false;
        }

        public void SetSessionValue<T>(string key, T value)
        {
            _httpContextAccessor.HttpContext.Session.SetString(key, value.ToString());
        }

        public T GetSessionValueAsJson<T>(string key)
        {
            if (_httpContextAccessor.HttpContext.Session.Keys.Contains(key))
            {
                var content = _httpContextAccessor.HttpContext.Session.GetString(key);
                var response = JsonSerializer.Deserialize<T>(content);
                return response;
            }
            return default;
        }

        public void SetSessionValueAsJson<T>(string key, T value)
        {
            if (_httpContextAccessor.HttpContext.Session.Keys.Contains(key))
                _httpContextAccessor.HttpContext.Session.Remove(key);
            _httpContextAccessor.HttpContext.Session.SetString(key, JsonSerializer.Serialize(value));
        }
    }
}