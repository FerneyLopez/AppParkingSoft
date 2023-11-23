using API_AppParkingSoft.DAL.Entities;

namespace API_AppParkingSoft.Domain.Interfaces
{
    public interface IReserveService
    {
        Task<IEnumerable<Reserve>> GetActiveReservesAsync();
        Task<IEnumerable<Reserve>> GetInactiveReservesAsync();
        Task<Reserve> EnterVehicleAsync(bool stateVehicle, string licensePlate);
        Task<Reserve> ExitVehicleAsync(bool stateVehicle, string licensePlate);
    }
}
