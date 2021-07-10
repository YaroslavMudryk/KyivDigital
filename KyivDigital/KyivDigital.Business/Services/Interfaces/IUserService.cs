using KyivDigital.Business.Models;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<NotificationsResponse> ChangeAllNotificationsAsync(NotificationChangeRequest notificationChangeRequest);
        Task<NotificationsResponse> ChangeNotificationByIdAsync(long id, NotificationChangeRequest notificationChangeRequest);
        Task<BaseResponse> ChangePhoneAsync(long id, LoginPhoneRequest loginPhoneRequest);
        Task<BaseResponse> DeleteAddressAsync(long id);
        Task<BaseResponse> DeleteProfileAsync();
        Task<ConnectBankUrl> GetBankIdLinkAsync();
        Task<Profile> GetUserProfileAsync();
        Task<Profile> GetUserProfileAsync(string accessToken);
        Task<AdressesListModel> GetUserAdressesAsync();
        Task<NotificationsResponse> GetUserNotificationsAsync();
        Task<Addresse> SaveAddressAsync(AddOrEditAddressRequest addOrEditAddressRequest);
        Task<Addresse> UpdateAddressAsync(long id, AddOrEditAddressRequest addOrEditAddressRequest);
        Task<UpdateProfileResponse> UpdateUserEmailAsync(ProfileEmailRequest profileEmailRequest);
        Task<Profile> UpdateUserImageAsync(string filePath);
        Task<BaseResponse> VerifyChangedPhoneAsync(LoginPhoneRequest loginPhoneRequest);
    }
}