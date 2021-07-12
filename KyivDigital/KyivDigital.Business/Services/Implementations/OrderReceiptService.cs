using KyivDigital.Business.Helpers;
using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Implementations
{
    public class OrderReceiptService : IOrderReceiptService
    {
        private readonly HttpClient _httpClient;
        private readonly IClaimsProvider _claimsProvider;
        public OrderReceiptService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            _httpClient = httpClient;
            _claimsProvider = claimsProvider;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
        }

        public async Task<FineOrderReceiptResponse> GetFineOrderReceiptAsync(string id)
        {
            string url = $"api/v3/order-receipt/{id}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<FineOrderReceiptResponse>(content);
            return voteResponse;
        }

        public async Task<BaseResponse> SendFineOrderReceiptAsync(long id, FineSendEmailRequest fineSendEmailRequest)
        {
            string url = $"api/v3/card/bank/otp";
            var requestContent = HttpConvertor.GetHttpContent(fineSendEmailRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<BaseResponse>(content);
            return voteResponse;
        }
    }
}