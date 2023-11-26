using API_AppParkingSoft.DAL.Entities;
using API_AppParkingSoft.DAL;
using API_AppParkingSoft.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_AppParkingSoft.Domain.Services
{
    public class RateService:IRateService
    {
        private readonly DataBaseContext _context;
        public RateService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rate>> GetRatesAsync()
        {
            return await _context.Rates
              .Include(r => r.CategoryVehicle)
                .Select(r => new Rate
                {
                    Id = r.Id,
                    RateName = r.RateName,
                    hourlyRate = r.hourlyRate,
                    weeklyRate = r.weeklyRate,
                    monthlyRate = r.monthlyRate,
                    CategoryVehicle = new CategoryVehicle
                    {
                        Id = r.CategoryVehicle.Id,
                        CategoryName = r.CategoryVehicle.CategoryName
                    },
                    idCategoryVehicle = r.idCategoryVehicle
                    
                })
                .ToListAsync();
        }

        public async Task<Rate> CreateRateAsync(Rate rate, Guid idCategoryVehicle)
        {
            try
            {
                rate.Id = Guid.NewGuid();
                rate.idCategoryVehicle = idCategoryVehicle;
                rate.CategoryVehicle = await _context.CategoryVehicles
                    .FirstOrDefaultAsync(c => c.Id == idCategoryVehicle);

                _context.Rates.Add(rate);
                await _context.SaveChangesAsync();

                return rate;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Rate> GetRateByNameAsync(string rateName)
        {
            return await _context.Rates.FirstOrDefaultAsync(r => r.RateName == rateName);
        }

        public async Task<Rate> EditRateAsync(Rate rate)
        {
            try
            {
                _context.Rates.Update(rate); 
                await _context.SaveChangesAsync();

                return rate;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Rate> DeleteRateAsync(Guid id)
        {
            try
            {
                var rate = await _context.Rates.FirstOrDefaultAsync(r => r.Id == id);

                if (rate == null) return null;

                _context.Rates.Remove(rate);
                await _context.SaveChangesAsync();

                return rate;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
