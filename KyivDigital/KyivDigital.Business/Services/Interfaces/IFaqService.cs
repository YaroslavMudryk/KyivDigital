using KyivDigital.Business.Models;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Interfaces
{
    public interface IFaqService
    {
        Task<CategotiesFaqResponse> GetCategoriesFaqAsync(string query, int with_top);
        
        Task<FaqDetailResponse> GetFaqDetailAsync(long id);

        Task<BaseResponse> VoteForFaqAsync(long id, RateFaqRequest rateFaqRequest);
    }
}