using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using KyivDigital.Business.WebHandlers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Implementations
{
    public class OrderReceiptService : IOrderReceiptService
    {
        private readonly KyivDigitalRequest _kyivDigitalRequest;
        public OrderReceiptService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            var token = claimsProvider.GetAccessToken();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _kyivDigitalRequest = new KyivDigitalRequest(httpClient);
        }

        public async Task<FineOrderReceiptResponse> GetFineOrderReceiptAsync(string id)
        {
            string url = $"api/v3/order-receipt/{id}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<FineOrderReceiptResponse>(content);
            return voteResponse;
        }

        public async Task<BaseResponse> SendFineOrderReceiptAsync(long id, FineSendEmailRequest fineSendEmailRequest)
        {
            string url = $"api/v3/order-receipt/{id}/send";
            var response = await _kyivDigitalRequest.PostAsync(url, fineSendEmailRequest);
            var content = await response.Content.ReadAsStringAsync();
            var voteResponse = JsonSerializer.Deserialize<BaseResponse>(content);
            return voteResponse;
        }
    }
}