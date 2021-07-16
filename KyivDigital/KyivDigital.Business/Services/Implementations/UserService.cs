using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using KyivDigital.Business.WebHandlers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace KyivDigital.Business.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly KyivDigitalRequest _kyivDigitalRequest;
        public UserService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            var token = claimsProvider.GetAccessToken();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _kyivDigitalRequest = new KyivDigitalRequest(httpClient);
        }

        public async Task<NotificationsResponse> ChangeAllNotificationsAsync(NotificationChangeRequest notificationChangeRequest)
        {
            var url = "api/v3/user/subscriptions/all";
            var response = await _kyivDigitalRequest.PostAsync(url, notificationChangeRequest);
            var content = await response.Content.ReadAsStringAsync();
            var notificationResponse = JsonSerializer.Deserialize<NotificationsResponse>(content);
            return notificationResponse;
        }

        public async Task<NotificationsResponse> ChangeNotificationByIdAsync(long id, NotificationChangeRequest notificationChangeRequest)
        {
            var url = $"api/v3/user/subscriptions/{id}";
            var response = await _kyivDigitalRequest.PostAsync(url, notificationChangeRequest);
            var content = await response.Content.ReadAsStringAsync();
            var notificationResponse = JsonSerializer.Deserialize<NotificationsResponse>(content);
            return notificationResponse;
        }

        public async Task<BaseResponse> ChangePhoneAsync(long id, LoginPhoneRequest loginPhoneRequest)
        {
            var url = "api/v3/user/phone/change";
            var response = await _kyivDigitalRequest.PostAsync(url, loginPhoneRequest);
            var content = await response.Content.ReadAsStringAsync();
            var phoneResponse = JsonSerializer.Deserialize<BaseResponse>(content);
            return phoneResponse;
        }

        public async Task<BaseResponse> DeleteAddressAsync(long id)
        {
            var url = "api/v3/user/addresses/{id}";
            var response = await _kyivDigitalRequest.DeleteAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var addressResponse = JsonSerializer.Deserialize<BaseResponse>(content);
            return addressResponse;
        }

        public async Task<BaseResponse> DeleteProfileAsync()
        {
            var url = "api/v3/user/profile";
            var response = await _kyivDigitalRequest.DeleteAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var profileResponse = JsonSerializer.Deserialize<BaseResponse>(content);
            return profileResponse;
        }

        public async Task<ConnectBankUrl> GetBankIdLinkAsync()
        {
            var url = "api/v3/user/bankid/link";
            var response = await _kyivDigitalRequest.DeleteAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var bankIdResponse = JsonSerializer.Deserialize<ConnectBankUrl>(content);
            return bankIdResponse;
        }

        public async Task<AdressesListModel> GetUserAdressesAsync()
        {
            var url = "api/v3/user/addresses";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var addressResponse = JsonSerializer.Deserialize<AdressesListModel>(content);
            return addressResponse;
        }

        public async Task<NotificationsResponse> GetUserNotificationsAsync()
        {
            var url = "api/v3/user/subscriptions";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var notificationResponse = JsonSerializer.Deserialize<NotificationsResponse>(content);
            return notificationResponse;
        }

        public async Task<Profile> GetUserProfileAsync()
        {
            var url = "api/v3/user/profile";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<Profile>(content);
            return feedResponse;
        }

        public async Task<Profile> GetUserProfileAsync(string accessToken)
        {
            var url = "api/v3/user/profile";
            var response = await _kyivDigitalRequest.GetAuthorizeAsync(url, accessToken);
            var content = await response.Content.ReadAsStringAsync();
            var feedResponse = JsonSerializer.Deserialize<Profile>(content);
            return feedResponse;
        }

        public async Task<Addresse> SaveAddressAsync(AddOrEditAddressRequest addOrEditAddressRequest)
        {
            var url = "api/v3/user/addresses";
            var response = await _kyivDigitalRequest.PostAsync(url, addOrEditAddressRequest);
            var content = await response.Content.ReadAsStringAsync();
            var addressResponse = JsonSerializer.Deserialize<Addresse>(content);
            return addressResponse;
        }

        public async Task<Addresse> UpdateAddressAsync(long id, AddOrEditAddressRequest addOrEditAddressRequest)
        {
            var url = $"api/v3/user/addresses/{id}";
            var response = await _kyivDigitalRequest.PutAsync(url, addOrEditAddressRequest);
            var content = await response.Content.ReadAsStringAsync();
            var addressResponse = JsonSerializer.Deserialize<Addresse>(content);
            return addressResponse;
        }

        public async Task<UpdateProfileResponse> UpdateUserEmailAsync(ProfileEmailRequest profileEmailRequest)
        {
            var url = $"api/v3/user/email/change";
            var response = await _kyivDigitalRequest.PostAsync(url, profileEmailRequest);
            var content = await response.Content.ReadAsStringAsync();
            var profileResponse = JsonSerializer.Deserialize<UpdateProfileResponse>(content);
            return profileResponse;
        }

        //public async Task<Profile> UpdateUserImageAsync(string filePath)
        //{
        //    var fileStream = new FileStream(filePath, FileMode.Open);
        //    var url = "api/v3/user/avatar";
        //    var fileNames = fileStream.Name.Split('/');
        //    var currentName = fileNames[fileNames.Length - 1];
        //    var response = await _kyivDigitalRequest.UploadAsync(_kyivDigitalRequest.BaseAddress.Host + "/" + url, new List<UploadEntry>
        //    {
        //        new UploadEntry(fileStream, "avatar", currentName)
        //    });
        //    return null;
        //}

        public async Task<BaseResponse> VerifyChangedPhoneAsync(LoginPhoneRequest loginPhoneRequest)
        {
            var url = $"api/v3/user/phone/change/verify";
            var response = await _kyivDigitalRequest.PostAsync(url, loginPhoneRequest);
            var content = await response.Content.ReadAsStringAsync();
            var baseResponse = JsonSerializer.Deserialize<BaseResponse>(content);
            return baseResponse;
        }
    }
}