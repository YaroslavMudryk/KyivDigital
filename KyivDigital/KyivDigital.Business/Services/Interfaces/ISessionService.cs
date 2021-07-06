namespace KyivDigital.Business.Services.Interfaces
{
    public interface ISessionService
    {
        T GetSessionValue<T>(string key);
        void SetSessionValue<T>(string key, T value);
        void ClearSessions();
        bool TryRemove(string key);
    }
}