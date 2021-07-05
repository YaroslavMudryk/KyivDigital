using KyivDigital.Business.Models;
using System.Threading.Tasks;

namespace KyivDigital.Business.Services.Interfaces
{
    public interface IHeadLineService
    {
        Task<HeadLineModel> GetHeadLineAsync();
    }
}