using KyivDigital.Business.Models;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Interfaces
{
    public interface IPinDataService
    {
        Task<BaseResponse> SetPinDataAsync(PinData pinData);
    }
}