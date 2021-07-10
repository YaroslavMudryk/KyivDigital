using KyivDigital.Business.Models;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Interfaces
{
    public interface IBankCardService
    {
        Task<MasterpassResponse> AddCardAsync();

        Task<OrderIdResponse> ConfirmCodeAsync(OtpRequest otpRequest);

        Task<MasterpassResponse> ConnectPhoneToMasterpassAsync(PhoneModel phoneModel);

        Task<BaseResponse> DeleteCardAsync(long id);

        Task<CardsList> GetCardsAsync();

        Task<PhoneModel> GetMasterpassPhoneAsync();

        Task<Card> SetMainCardAsync(long id, MainCardRequest mainCardRequest);
    }
}