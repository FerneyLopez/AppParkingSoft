using API_AppParkingSoft.DAL;
using API_AppParkingSoft.DAL.Entities;
using API_AppParkingSoft.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace API_AppParkingSoft.Domain.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly DataBaseContext _context;
        public VehicleService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Vehicle>> GetVehiclesAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }
        public async Task<Vehicle> CreateVehicleAsync(Vehicle vehicle)
        {
            try
            {
                vehicle.Id = Guid.NewGuid();

                _context.Vehicles.Add(vehicle);
                await _context.SaveChangesAsync();

                return vehicle;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<Vehicle> GetVehicleByLicensePlateAsync(string licensePlate)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(v => v.LicensePlate == licensePlate);
        }
        public async Task<Vehicle> EditVehicleAsync(Vehicle vehicle, Guid clientId)
        {
            try
            {

                _context.Vehicles.Update(vehicle);
                await _context.SaveChangesAsync();

                return vehicle;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Vehicle> DeleteVehicleAsync(Guid id)
        {
            try
            {
                var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);

                if (vehicle == null) return null;

                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();

                return vehicle;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
