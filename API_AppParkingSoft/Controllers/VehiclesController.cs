﻿using API_AppParkingSoft.DAL.Entities;
using API_AppParkingSoft.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_AppParkingSoft.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleService _vehicleService;
        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        [HttpGet, ActionName("Get")]
        [Route("GetVehicles")]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehiclesAsync()
        {
            var vehicles = await _vehicleService.GetVehiclesAsync();

            if (vehicles == null || !vehicles.Any()) return NotFound();

            return Ok(vehicles);
        }

        [HttpPost, ActionName("Create")]
        [Route("CreateVehicles")]
        public async Task<ActionResult> CreateVehicleAsync(Vehicle vehicle, Guid clientId)
        {
            try
            {
                var createdVehicle = await _vehicleService.CreateVehicleAsync(vehicle, clientId);

                if (createdVehicle == null) return NotFound();

                return Ok(createdVehicle);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("Ya existe la licensia {0}.", vehicle.LicensePlate));
                }

                return Conflict(ex.Message);
            }
        }

        [HttpGet, ActionName("Get")]
        [Route("GetByVehiclesLicensePlate/{LicensePlate}")]
        public async Task<ActionResult<Vehicle>> GetVehicleByLicensePlateAsync(string licensePlate)
        {
            if (licensePlate == null) return BadRequest("La placa es requerida!");

            var state = await _vehicleService.GetVehicleByLicensePlateAsync(licensePlate);

            if (state == null) return NotFound();

            return Ok(state);
        }

        [HttpPut, ActionName("Edit")]
        [Route("EditVehicles")]
        public async Task<ActionResult<Vehicle>> EditVehicleAsync(Vehicle vehicle, Guid clientId)
        {
            try
            {
                var editedVehicle = await _vehicleService.EditVehicleAsync(vehicle, clientId);
                return Ok(editedVehicle);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", vehicle.LicensePlate));

                return Conflict(ex.Message);
            }
        }
    }
}
