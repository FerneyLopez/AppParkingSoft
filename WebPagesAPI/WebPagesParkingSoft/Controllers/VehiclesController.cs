﻿using API_AppParkingSoft.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebPagesParkingSoft.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public VehiclesController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var url = "https://localhost:7211/api/Vehicles/GetVehicles";
            var json = await _httpClient.CreateClient().GetStringAsync(url);
            List<Vehicle> vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(json);

            return View(vehicles);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vehicle vehicle)
        {
            var url = "https://localhost:7211/api/Vehicles/CreateVehicles";
            await _httpClient.CreateClient().PostAsJsonAsync(url, vehicle);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Vehicle vehicle, Guid? id)
        {
            var url = String.Format("https://localhost:7211/api/Vehicles/EditVehicles/{0}", id);
            var json = await _httpClient.CreateClient().GetStringAsync(url);
            vehicle = JsonConvert.DeserializeObject<Vehicle>(json);
            return View(vehicle);
        }
    }
}
