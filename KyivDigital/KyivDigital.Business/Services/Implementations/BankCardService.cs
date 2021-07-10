using KyivDigital.Business.Helpers;
using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace KyivDigital.Business.Services.Implementations
{
    public class BankCardService : IBankCardService
    {
        private readonly HttpClient _httpClient;
        private readonly IClaimsProvider _claimsProvider;
        public BankCardService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            _httpClient = httpClient;
            _claimsProvider = claimsProvider;
        }

        public async Task<MasterpassResponse> AddCardAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/card/bank/add";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<MasterpassResponse>(content);
            return voteResponse;
        }

        public async Task<OrderIdResponse> ConfirmCodeAsync(OtpRequest otpRequest)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/card/bank/otp";
            var requestContent = HttpConvertor.GetHttpContent(otpRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<OrderIdResponse>(content);
            return voteResponse;
        }

        public async Task<MasterpassResponse> ConnectPhoneToMasterpassAsync(PhoneModel phoneModel)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = "api/v3/card/bank/phone";
            var requestContent = HttpConvertor.GetHttpContent(phoneModel);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<MasterpassResponse>(content);
            return voteResponse;
        }

        public async Task<BaseResponse> DeleteCardAsync(long id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/card/bank/{id}";
            var response = await _httpClient.DeleteAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<BaseResponse>(content);
            return voteResponse;
        }

        public async Task<CardsList> GetCardsAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = "api/v3/card/bank";
            var response = await _httpClient.DeleteAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<CardsList>(content);
            return voteResponse;
        }

        public async Task<PhoneModel> GetMasterpassPhoneAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = "api/v3/card/bank/phone";
            var response = await _httpClient.DeleteAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<PhoneModel>(content);
            return voteResponse;
        }

        public async Task<Card> SetMainCardAsync(long id, MainCardRequest mainCardRequest)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/card/bank/{id}/main";
            var requestContent = HttpConvertor.GetHttpContent(mainCardRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<Card>(content);
            return voteResponse;
        }
    }
}