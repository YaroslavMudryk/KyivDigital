using KyivDigital.Business.Models;
using KyivDigital.Business.Services.Interfaces;
using KyivDigital.Business.WebHandlers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace KyivDigital.Business.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly KyivDigitalRequest _kyivDigitalRequest;
        public CarService(HttpClient httpClient, IClaimsProvider claimsProvider)
        {
            var token = claimsProvider.GetAccessToken();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _kyivDigitalRequest = new KyivDigitalRequest(httpClient);
        }

        public async Task<BaseResponse> DeleteCarAsync(long id)
        {
            string url = $"api/v3/cars/{id}";
            var response = await _kyivDigitalRequest.DeleteAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var carResponse = JsonSerializer.Deserialize<BaseResponse>(content);
            return carResponse;
        }

        public async Task<CarModel> GetCarByIdAsync(long id)
        {
            string url = $"api/v3/cars/{id}";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var carResponse = JsonSerializer.Deserialize<CarModel>(content);
            return carResponse;
        }

        public async Task<CarsResponse> GetCarsAsync()
        {
            string url = "api/v3/cars";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var carResponse = JsonSerializer.Deserialize<CarsResponse>(content);
            return carResponse;
        }

        public async Task<CarVerificationDataResponse> GetCarVerificationDataAsync(long id)
        {
            string url = $"api/v3/cars/{id}/verification";
            var response = await _kyivDigitalRequest.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var carResponse = JsonSerializer.Deserialize<CarVerificationDataResponse>(content);
            return carResponse;
        }

        public async Task<BaseResponse> MakeCarVerificationAsync(long id, CarVerificationRequest carVerificationRequest)
        {
            string url = $"api/v3/cars/{id}/verification";
            var response = await _kyivDigitalRequest.PostAsync(url, carVerificationRequest);
            var content = await response.Content.ReadAsStringAsync();
            var carResponse = JsonSerializer.Deserialize<BaseResponse>(content);
            return carResponse;
        }

        public async Task<CarModel> StoreCarAsync(CarRequest carRequest)
        {
            string url = "api/v3/cars";
            var response = await _kyivDigitalRequest.PostAsync(url, carRequest);
            var content = await response.Content.ReadAsStringAsync();
            var carResponse = JsonSerializer.Deserialize<CarModel>(content);
            return carResponse;
        }

        public async Task<CarModel> UpdateCarAsync(long id, CarUpdateRequest carUpdateRequest)
        {
            string url = $"api/v3/cars/{id}";
            var response = await _kyivDigitalRequest.PutAsync(url, carUpdateRequest);
            var content = await response.Content.ReadAsStringAsync();
            var carResponse = JsonSerializer.Deserialize<CarModel>(content);
            return carResponse;
        }
    }
}