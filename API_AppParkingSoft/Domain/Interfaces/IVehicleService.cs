using API_AppParkingSoft.DAL.Entities;
using System.Diagnostics.Metrics;

namespace API_AppParkingSoft.Domain.Interfaces
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetVehiclesAsync();
        Task<Vehicle> CreateVehicleAsync(Vehicle vehicle, Guid clientId);
        Task<Vehicle> GetVehicleByLicensePlateAsync(string licensePlate);
        Task<Vehicle> EditVehicleAsync(Vehicle vehicle, Guid clientId);
    }
}
