using API_AppParkingSoft.DAL;
using API_AppParkingSoft.DAL.Entities;
using API_AppParkingSoft.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

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
        public async Task<Reserve> ExitVehicleAsync( string licensePlate)
        {
            try
            {


                var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.LicensePlate == licensePlate);
                if (vehicle == null) return null;

                var reserve = await _context.Reserves
                    .FirstOrDefaultAsync(r => r.LicensePlate == licensePlate);

                reserve.Id = Guid.NewGuid();
                var date1 = DateTime.Now; //reserve.EndDate = DateTime.Now;
                reserve.EndDate = date1;
                reserve.LicensePlate = licensePlate;
                reserve.activeVehicle = false;


                TimeSpan interval = (TimeSpan)(date1 - reserve.StartDate);
                Console.WriteLine(date1);
                Console.WriteLine(reserve.StartDate);
                Console.WriteLine(interval.TotalHours);
                Console.WriteLine(interval);
                


                reserve.TotalCost = interval.TotalHours * 60;



                _context.Reserves.Add(reserve);
                await _context.SaveChangesAsync();



                return reserve;
               



            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }

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
