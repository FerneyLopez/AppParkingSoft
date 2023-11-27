using API_AppParkingSoft.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebPagesParkingSoft.Controllers
{
    public class ReservesController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public ReservesController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var url = "https://localhost:7211/api/Reserve/GetActiveVehicles";
            var json = await _httpClient.CreateClient().GetStringAsync(url);
            List<Reserve> reserves = JsonConvert.DeserializeObject<List<Reserve>>(json);

            return View(reserves);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
