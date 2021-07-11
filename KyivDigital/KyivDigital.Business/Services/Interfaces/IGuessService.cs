using KyivDigital.Business.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace KyivDigital.Business.Services.Interfaces
{
    public interface IGuessService
    {
        Task<StreetAddressResponse> GetStreetsAsync(string street);
        Task<AoAddressResponse> GetHousesAsync(string streetId, string house);
        Task<PremiseAddressResponse> GetFlatsAsync(string houseId, string premise);
    }
}