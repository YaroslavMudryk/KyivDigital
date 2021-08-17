using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using KyivDigital.Business.WebHandlers;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace KyivDigital.Business.Services.Implementations
{
    public class GBProjectService : IGBProjectService
    {
        private readonly KyivDigitalRequest _kyivDigitalRequest;
        private readonly IClaimsProvider _claimsProvider;
        public GBProjectService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            _claimsProvider = claimsProvider;
            var token = claimsProvider.GetAccessToken();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _kyivDigitalRequest = new KyivDigitalRequest(httpClient);
        }

        public async Task<PublicBudgetResponse> GetGbProjectsAsync(int page = 1, int seed = default, string search = null, List<int> filtersDist = null, List<int> filtersCategory = null)
        {
            string url = null;
            if (seed == default && search == null && filtersDist == null && filtersCategory == null)
                url = "api/v3/gb/projects";
            else
                url = $"api/v3/gb/projects?page={page}&seed={seed}&search={search}&filters[districts][]={filtersDist}&filters[categories][]={filtersCategory}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<PublicBudgetResponse>(content);
        }

        public async Task<PublicBudgetResponse> GetGbVotedProjectsAsync(int page = 1)
        {
            string url = $"api/v3/gb/projects/voted?page={page}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<PublicBudgetResponse>(content);
        }

        public async Task<ProjectDetailsResponse> GetProjectDetailsAsync(string id)
        {
            string url = $"api/v3/gb/projects/{id}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ProjectDetailsResponse>(content);
        }

        public async Task<ProjectVoteResponse> VoteForProjectAsync(int id)
        {
            string url = $"api/v3/gb/projects/{id}/vote";
            var response = await _kyivDigitalRequest.PostAsync(url, null);
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ProjectVoteResponse>(content);
        }
    }
}
