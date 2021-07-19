using System.Threading.Tasks;
namespace KyivDigital.Business.Storage
{
    public interface IStorageService<T>
    {
        void Post(string key, T data);
        Task PostAsync(string key, T data);
        T Get(string key);
        Task<T> GetAsync(string key);
    }
}