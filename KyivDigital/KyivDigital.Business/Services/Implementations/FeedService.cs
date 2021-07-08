using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Implementations
{
    public class FeedService : IFeedService
    {
        private readonly HttpClient _httpClient;
        private readonly IClaimsProvider _claimsProvider;
        public FeedService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            _httpClient = httpClient;
            _claimsProvider = claimsProvider;
        }
        public async Task<PagedFeedResponse> GetPagedUserHistoryAsync(int page = default, int count = default)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = "";
            if (page == default && count == default)
                url = "api/v3/feed";
            else
                url = $"api/v3/feed?page={page}&per_page={count}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<PagedFeedResponse>(content);
            return feedResponse;
        }
    }

    public class MockFeedService : IFeedService
    {
        private readonly HttpClient _httpClient;
        public MockFeedService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PagedFeedResponse> GetPagedUserHistoryAsync(int page = 0, int count = 0)
        {
            return await Task.Run(() =>
            {
                return new PagedFeedResponse()
                {
                    ErrorMessage = null,
                    Feed = new FeedData
                    {
                        Data = new List<FeedItemModel>
                        {
                            new FeedItemModel
                            {
                                Title = "aefaseferg",
                                CreatedAt = DateTime.Now,
                                Description = "elrjhnlherijg",
                                Id = Guid.NewGuid().ToString("N"),
                                Icon = "https://kyiv.digital/storage/i/cai_yIXZJ.png"
                            },
                            new FeedItemModel
                            {
                                Title = "aefaseferg",
                                CreatedAt = DateTime.UtcNow,
                                Description = "elrjhnlherijg",
                                Id = Guid.NewGuid().ToString("N"),
                                Icon = "https://kyiv.digital/storage/i/cai_yIXZJ.png"
                            },
                            new FeedItemModel
                            {
                                Title = "aefaseferg",
                                CreatedAt = DateTime.Now,
                                Description = "elrjhnlherijg",
                                Id = Guid.NewGuid().ToString("N"),
                                Icon = "https://kyiv.digital/storage/i/cai_yIXZJ.png"
                            },
                            new FeedItemModel
                            {
                                Title = "aefaseferg",
                                CreatedAt = DateTime.UtcNow,
                                Description = "elrjhnlherijg",
                                Id = Guid.NewGuid().ToString("N"),
                                Icon = "https://kyiv.digital/storage/i/cai_yIXZJ.png"
                            },
                            new FeedItemModel
                            {
                                Title = "aefaseferg",
                                CreatedAt = DateTime.Now,
                                Description = "elrjhnlherijg",
                                Id = Guid.NewGuid().ToString("N"),
                                Icon = "https://kyiv.digital/storage/i/cai_yIXZJ.png"
                            },
                            new FeedItemModel
                            {
                                Title = "aefaseferg",
                                CreatedAt = DateTime.UtcNow,
                                Description = "elrjhnlherijg",
                                Id = Guid.NewGuid().ToString("N"),
                                Icon = "https://kyiv.digital/storage/i/cai_yIXZJ.png"
                            }
                        },
                        Meta = new Meta
                        {
                            Pagination = new Pagination
                            {
                                Count = 20,
                                CurrentPage = 1,
                                PerPage = 20,
                                Total = 69,
                                TotalPages = 4,
                                Links = new Links
                                {
                                    Next = "",
                                    Previous = ""
                                }
                            }
                        }
                    }
                };
            });
        }
    }
}