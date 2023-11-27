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
        public async Task<Reserve> ExitVehicleAsync(string licensePlate)
        {
            try
            {


                /*var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.LicensePlate == licensePlate);
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
                


                reserve.TotalCost = interval.TotalHours * 60;*/

                var vehicle = await _context.Vehicles
                   .Include(v => v.CategoryVehicle)
                        .ThenInclude(cv => cv.Rate)
                   .FirstOrDefaultAsync(v => v.LicensePlate == licensePlate);
                
                if (vehicle == null) return null;

                var reserve = await _context.Reserves
                    .FirstOrDefaultAsync(r => r.LicensePlate == licensePlate);

                reserve.Id = Guid.NewGuid();
                var date1 = DateTime.Now; //reserve.EndDate = DateTime.Now;
                reserve.EndDate = date1;
                reserve.LicensePlate = licensePlate;
                reserve.activeVehicle = false;

                TimeSpan interval = date1 - reserve.StartDate;

                var rate = vehicle?.CategoryVehicle?.Rate;
                
                

                if (rate == null)
                {
                    throw new InvalidOperationException($"No existe una tarifa asociada para el vehiculo con la placa: {licensePlate}");
                }

                // Calculate cost (Private method)
                reserve.TotalCost = CalculateTotalCost(interval, rate);

                vehicle.CategoryVehicle.Rate.Id = rate.Id;

                _context.Reserves.Add(reserve);
                await _context.SaveChangesAsync();

                return reserve;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }

        }

        public async Task<IEnumerable<Reserve>> GetActiveReservesAsync()
        {
            return await _context.Reserves.Where(r => r.activeVehicle == true)
                .ToListAsync();
        }

        public async Task<IEnumerable<Reserve>> GetInactiveReservesAsync()
        {
            return await _context.Reserves.Where(r => r.activeVehicle == false)
                .ToListAsync();
        }


        #region Private Method
        private double CalculateTotalCost(TimeSpan interval, Rate rate)
        {
            double TotalCost = 0;

            if (interval.TotalHours <= 1)
            {
                TotalCost = interval.TotalHours * rate.hourlyRate;
            }
            else if (interval.TotalDays <= 1)
            {
                TotalCost = interval.TotalDays * rate.dailyRate;
            }
            else if (interval.TotalDays <= 7)
            {
                TotalCost = interval.TotalDays * rate.weeklyRate;
            }
            else
            {
                TotalCost = interval.TotalDays * rate.monthlyRate;
            }

            return TotalCost;
        }
        #endregion
    }
}
