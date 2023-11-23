using API_AppParkingSoft.DAL.Entities;
using API_AppParkingSoft.Domain.Interfaces;

namespace API_AppParkingSoft.Domain.Services
{
    public class ReserveService : IReserveService
    {
        public Task<Reserve> EnterVehicleAsync(bool stateVehicle, string licensePlate)
        {
            throw new NotImplementedException();
        }

        public Task<Reserve> ExitVehicleAsync(bool stateVehicle, string licensePlate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reserve>> GetActiveReservesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reserve>> GetInactiveReservesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
