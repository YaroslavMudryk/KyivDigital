using KyivDigital.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KyivDigital.Business.Services.Interfaces
{
    public interface IGBProjectService
    {
        Task<PublicBudgetResponse> GetGbProjectsAsync(int page, int seed, string search, List<int> filtersDist, List<int> filtersCategory);
        Task<PublicBudgetResponse> GetGbVotedProjectsAsync(int page);
        Task<ProjectDetailsResponse> GetProjectDetailsAsync(string id);
        Task<ProjectVoteResponse> VoteForProjectAsync(int id);
    }
}