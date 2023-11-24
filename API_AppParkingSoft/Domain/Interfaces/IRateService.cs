using API_AppParkingSoft.DAL.Entities;

namespace API_AppParkingSoft.Domain.Interfaces
{
    public interface IRateService
    {
        Task<IEnumerable<Rate>> GetRatesAsync();
        Task<Rate> CreateRateAsync(Rate rate, Guid idCategoryVehicle);
        Task<Rate> GetRateByNameAsync(String rateName);
        Task<Rate> EditRateAsync(Rate rate);
        Task<Rate> DeleteRateAsync(Guid id);
    }
}
