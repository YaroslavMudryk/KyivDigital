using KyivDigital.Business.Models;
using System.Threading.Tasks;

namespace KyivDigital.Business.Services.Interfaces
{
    public interface ICarService
    {
        Task<BaseResponse> DeleteCarAsync(long id);
        Task<CarModel> GetCarByIdAsync(long id);
        Task<CarVerificationDataResponse> GetCarVerificationDataAsync(long id);
        Task<CarsResponse> GetCarsAsync();
        Task<BaseResponse> MakeCarVerificationAsync(long id, CarVerificationRequest carVerificationRequest);
        Task<CarModel> StoreCarAsync(CarRequest carRequest);
        Task<CarModel> UpdateCarAsync(long id, CarUpdateRequest carUpdateRequest);
    }
}