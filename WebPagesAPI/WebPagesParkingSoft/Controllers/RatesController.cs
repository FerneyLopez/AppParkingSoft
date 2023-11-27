using API_AppParkingSoft.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebPagesParkingSoft.Controllers
{
    public class RatesController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public RatesController(IHttpClientFactory httpClient) {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var url = "https://localhost:7211/api/Rates/GetRates";
            var json = await _httpClient.CreateClient().GetStringAsync(url);
            List<Rate> Rates = JsonConvert.DeserializeObject<List<Rate>>(json);

            return View(Rates);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Rate Rate)
        {
            var url = "https://localhost:7211/api/Rates/CreateRates";
            await _httpClient.CreateClient().PostAsJsonAsync(url, Rate);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            var url = String.Format("https://localhost:7211/api/Rates/EditRates/{0}", id);
            var json = await _httpClient.CreateClient().GetStringAsync(url);
            Rate Rate = JsonConvert.DeserializeObject<Rate>(json);
            return View(Rate);
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Rate Rate, Guid? id)
        {
            var url = String.Format("https://localhost:7211/api/Rates/EditRates/{0}", id);
            await _httpClient.CreateClient().PutAsJsonAsync(url, Rate);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            var url = String.Format("https://localhost:7211/api/Rates/GetRates/{0}", id);
            var json = await _httpClient.CreateClient().GetStringAsync(url);
            Rate Rate = JsonConvert.DeserializeObject<Rate>(json);
            return View(Rate);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            var url = String.Format("https://localhost:7211/api/Rates/GetRates/{0}", id);
            await _httpClient.CreateClient().DeleteAsync(url);
            return RedirectToAction("Index");
        }*/
    }
}
