using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Net.Http;
using Newtonsoft.Json;
using API_AppParkingSoft.DAL.Entities;

namespace WebPagesParkingSoft.Controllers
{
    public class RatesController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public RatesController(IHttpClientFactory httpClient) {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var url = "https://localhost:7211/api/Rate/GetRate";
            var json = await _httpClient.CreateClient().GetStringAsync(url);
            List<Rate> rates = JsonConvert.DeserializeObject<List<Rate>>(json);

            return View(rates);
        }
    }
}
