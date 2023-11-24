using API_AppParkingSoft.DAL;
using API_AppParkingSoft.DAL.Entities;
using API_AppParkingSoft.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_AppParkingSoft.Domain.Services
{
    public class ReserveService : IReserveService
    {
        private readonly DataBaseContext _context;
        public ReserveService(DataBaseContext context)
        {
            _context = context;
        }

        //Vehicles Enter
        public async Task<Reserve> CreateReserveAsync(string licensePlate)
        {
            try
            {
                var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.LicensePlate == licensePlate);
                if (vehicle == null) return null;

                var reserve = await _context.Reserves
                    .FirstOrDefaultAsync();

                reserve.Id = Guid.NewGuid();
                reserve.StartDate = DateTime.Now;
                reserve.EndDate = null;
                reserve.LicensePlate = licensePlate;
                reserve.activeVehicle = true;

                _context.Reserves.Add(reserve);
                await _context.SaveChangesAsync();

                return reserve;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        //Vehicles Exit
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
