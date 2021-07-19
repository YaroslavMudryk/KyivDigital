using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KyivDigital.Business.Storage
{
    public class InMemoryStorageService<T> : IStorageService<T>
    {
        private readonly Dictionary<string, T> _storages;
        public InMemoryStorageService()
        {
            _storages = new Dictionary<string, T>();
        }

        public T Get(string key)
        {
            if (_storages.ContainsKey(key))
                return _storages[key];
            return default;
        }

        public async Task<T> GetAsync(string key)
        {
            if (_storages.ContainsKey(key))
                return await Task.Run(() => { return _storages[key]; });
            return default;
        }

        public void Post(string key, T data)
        {
            if (_storages.ContainsKey(key))
                _storages.Remove(key);
            _storages.Add(key, data);
        }

        public Task PostAsync(string key, T data)
        {
            if (_storages.ContainsKey(key))
                _storages.Remove(key);
            _storages.Add(key, data);
            return Task.CompletedTask;
        }
    }
}
