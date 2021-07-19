using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace KyivDigital.Business.Storage
{
    public class FileStorageService<T> : IStorageService<T>
    {
        private readonly string _fileName = "FileStorage.json";

        private Dictionary<string, T> _storages;

        public FileStorageService()
        {
            uploadFromFileAsync().GetAwaiter().GetResult();
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
            downloadToFileAsync().GetAwaiter().GetResult();
        }

        public async Task PostAsync(string key, T data)
        {
            if (_storages.ContainsKey(key))
                _storages.Remove(key);
            _storages.Add(key, data);
            await downloadToFileAsync();
        }

        private async Task downloadToFileAsync()
        {
            if (!File.Exists(_fileName))
                File.Create(_fileName);
            var contentToSave = JsonSerializer.Serialize(_storages);
            using var sw = new StreamWriter(_fileName);
            await sw.WriteLineAsync(contentToSave);
        }
        private async Task uploadFromFileAsync()
        {
            if (!File.Exists(_fileName))
            {
                _storages = new Dictionary<string, T>();
                return;
            }
            using var sr = new StreamReader(_fileName);
            var contentFromFile = await sr.ReadToEndAsync();
            var convertedFromContent = JsonSerializer.Deserialize<Dictionary<string, T>>(contentFromFile);
            _storages = convertedFromContent;
        }
    }
}
