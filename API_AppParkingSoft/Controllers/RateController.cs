using API_AppParkingSoft.DAL.Entities;
using API_AppParkingSoft.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_AppParkingSoft.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RateController : Controller
    {
        private readonly IRateService _rateService;

        public RateController(IRateService rateService)
        {
            _rateService = rateService;
        }


        [HttpGet, ActionName("Get")]
        [Route("GetRate")]
        public async Task<ActionResult<IEnumerable<Rate>>> GetRatesAsync()
        {
            var rates = await _rateService.GetRatesAsync();

            if (rates == null || !rates.Any()) return NotFound();

            return Ok(rates);
        }

        [HttpPost, ActionName("Create")]
        [Route("CreateRate")]
        public async Task<ActionResult<Rate>> CreateRateAsync(Rate rate, Guid idCategoryVehicle)
        {
            try
            {
                var createdRate = await _rateService.CreateRateAsync(rate, idCategoryVehicle);

                if (createdRate == null) return NotFound();

                return Ok(createdRate);
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("duplicated"))
                {
                    return Conflict(String.Format("La Tarifa {0} ya existe.", rate.Id));

                }

                return Conflict(ex.Message);
            }
        }

        [HttpGet, ActionName("Get")]
        [Route("GetRateByRateName/{rateName}")]
        public async Task<ActionResult<IEnumerable<Rate>>> GetRateByNameAsync(String rateName)
        {
            if (rateName == null) return BadRequest("El nombre de la tarifa es obligatorio!");

            var rate = await _rateService.GetRateByNameAsync(rateName);

            if (rate == null) return NotFound();

            return Ok(rate);
        }

        [HttpPut, ActionName("Edit")]
        [Route("EditRate")]
        public async Task<ActionResult<Rate>> EditRateAsync(Rate rate)
        {
            try
            {
                var editedRate = await _rateService.EditRateAsync(rate);

                return Ok(editedRate);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicated"))
                {
                    return Conflict(String.Format("El Ratee {0} ya existe.", rate.Id));

                }

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("DeleteRate")]
        public async Task<ActionResult<Rate>> DeleteRateAsync(Guid id)
        {
            if (id == null) return BadRequest("Id es requerido");

            var deleteRate = await _rateService.DeleteRateAsync(id);

            if (deleteRate == null) return NotFound("Rate no encontrado");

            return Ok(deleteRate);
        }
    }
}
