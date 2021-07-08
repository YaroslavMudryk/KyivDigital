﻿using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace KyivDigital.Business.Services.Implementations.Mocks
{
    public class FileFeedService : IFeedService
    {
        public FileFeedService(HttpClient httpClient)
        {

        }
        public async Task<PagedFeedResponse> GetPagedUserHistoryAsync(int page = 0, int count = 0)
        {
            using var sr = new StreamReader(@"D:\Projects\KyivDigital\KyivDigital\KyivDigital.Business\bin\Debug\net5.0\Mocks\AllFeed.json");
            var content = await sr.ReadToEndAsync();
            var feedResponse = JsonSerializer.Deserialize<PagedFeedResponse>(content);
            return feedResponse;
        }
    }
}