using KyivDigital.Business.Helpers;
using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace KyivDigital.Business.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly HttpClient _httpClient;
        private readonly IClaimsProvider _claimsProvider;
        public CarService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            _httpClient = httpClient;
            _claimsProvider = claimsProvider;
        }

        public async Task<BaseResponse> DeleteCarAsync(long id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/cars/{id}";
            var response = await _httpClient.DeleteAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var carResponse = JsonSerializer.Deserialize<BaseResponse>(content);
            return carResponse;
        }

        public async Task<CarModel> GetCarByIdAsync(long id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/cars/{id}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var carResponse = JsonSerializer.Deserialize<CarModel>(content);
            return carResponse;
        }

        public async Task<CarsResponse> GetCarsAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = "api/v3/cars";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var carResponse = JsonSerializer.Deserialize<CarsResponse>(content);
            return carResponse;
        }

        public async Task<CarVerificationDataResponse> GetCarVerificationDataAsync(long id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/cars/{id}/verification";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var carResponse = JsonSerializer.Deserialize<CarVerificationDataResponse>(content);
            return carResponse;
        }

        public async Task<BaseResponse> MakeCarVerificationAsync(long id, CarVerificationRequest carVerificationRequest)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/cars/{id}/verification";
            var requestContent = HttpConvertor.GetHttpContent(carVerificationRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var carResponse = JsonSerializer.Deserialize<BaseResponse>(content);
            return carResponse;
        }

        public async Task<CarModel> StoreCarAsync(CarRequest carRequest)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = "api/v3/cars";
            var requestContent = HttpConvertor.GetHttpContent(carRequest);
            var response = await _httpClient.PostAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var carResponse = JsonSerializer.Deserialize<CarModel>(content);
            return carResponse;
        }

        public async Task<CarModel> UpdateCarAsync(long id, CarUpdateRequest carUpdateRequest)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _claimsProvider.GetAccessToken());
            string url = $"api/v3/cars/{id}";
            var requestContent = HttpConvertor.GetHttpContent(carUpdateRequest);
            var response = await _httpClient.PutAsync(url, requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var carResponse = JsonSerializer.Deserialize<CarModel>(content);
            return carResponse;
        }
    }
}