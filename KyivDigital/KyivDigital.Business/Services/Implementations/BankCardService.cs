using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using KyivDigital.Business.WebHandlers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace KyivDigital.Business.Services.Implementations
{
    public class BankCardService : IBankCardService
    {
        private readonly KyivDigitalRequest _kyivDigitalRequest;
        public BankCardService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            var token = claimsProvider.GetAccessToken();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _kyivDigitalRequest = new KyivDigitalRequest(httpClient);
        }

        public async Task<MasterpassResponse> AddCardAsync()
        {
            string url = $"api/v3/card/bank/add";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<MasterpassResponse>(content);
            return voteResponse;
        }

        public async Task<OrderIdResponse> ConfirmCodeAsync(OtpRequest otpRequest)
        {
            string url = $"api/v3/card/bank/otp";
            var response = await _kyivDigitalRequest.PostAsync(url, otpRequest);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<OrderIdResponse>(content);
            return voteResponse;
        }

        public async Task<MasterpassResponse> ConnectPhoneToMasterpassAsync(PhoneModel phoneModel)
        {
            string url = "api/v3/card/bank/phone";
            var response = await _kyivDigitalRequest.PostAsync(url, phoneModel);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<MasterpassResponse>(content);
            return voteResponse;
        }

        public async Task<BaseResponse> DeleteCardAsync(long id)
        {
            string url = $"api/v3/card/bank/{id}";
            var response = await _kyivDigitalRequest.DeleteAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<BaseResponse>(content);
            return voteResponse;
        }

        public async Task<CardsList> GetCardsAsync()
        {
            string url = "api/v3/card/bank";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<CardsList>(content);
            return voteResponse;
        }

        public async Task<PhoneModel> GetMasterpassPhoneAsync()
        {
            string url = "api/v3/card/bank/phone";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<PhoneModel>(content);
            return voteResponse;
        }

        public async Task<Card> SetMainCardAsync(long id, MainCardRequest mainCardRequest)
        {
            string url = $"api/v3/card/bank/{id}/main";
            var response = await _kyivDigitalRequest.PostAsync(url, mainCardRequest);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<Card>(content);
            return voteResponse;
        }
    }
}