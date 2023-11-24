using API_AppParkingSoft.DAL.Entities;
using API_AppParkingSoft.Domain.Interfaces;
using API_AppParkingSoft.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_AppParkingSoft.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReserveController : Controller
    {
        private readonly IReserveService _reserveService;

        public ReserveController(IReserveService reserveService)
        {
            _reserveService = reserveService;
        }

        [HttpPost, ActionName("Create")]
        [Route("CreateReserve")]
        public async Task<ActionResult<Rate>> CreateReserveAsync(string licensePlate)
        {
            try
            {
                var createdReserve = await _reserveService.CreateReserveAsync(licensePlate);

                if (createdReserve == null) return NotFound();

                return Ok(createdReserve);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
