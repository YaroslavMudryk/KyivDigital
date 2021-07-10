using KyivDigital.Business.Models;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Interfaces
{
    public interface IOrderReceiptService
    {
        Task<FineOrderReceiptResponse> GetFineOrderReceiptAsync(string id);

        Task<BaseResponse> SendFineOrderReceiptAsync(long id, FineSendEmailRequest fineSendEmailRequest);
    }
}