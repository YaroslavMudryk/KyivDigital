using Microsoft.AspNetCore.Http;
namespace KyivDigital.Business.Services.Interfaces
{
    public interface ISessionService
    {
        T GetSessionValue<T>(string key);
        T GetSessionValueAsJson<T>(string key);
        void SetSessionValue<T>(string key, T value);
        void SetSessionValueAsJson<T>(string key, T value);
        void ClearSessions();
        bool TryRemove(string key);
    }
}