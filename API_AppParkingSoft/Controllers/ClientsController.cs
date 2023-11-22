using API_AppParkingSoft.DAL.Entities;
using API_AppParkingSoft.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_AppParkingSoft.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }


        [HttpGet, ActionName("Get")]
        [Route("GetClient")]
        public async Task<ActionResult<IEnumerable<Client>>> GetClientsAsync()
        {
            var clients = await _clientService.GetClientsAsync();

            if (clients == null || !clients.Any()) return NotFound();

            return Ok(clients);
        }

        [HttpPost, ActionName("Create")]
        [Route("CreateClient")]
        public async Task<ActionResult<Client>> CreateClientAsync(Client client)
        {
            try
            {
                var createdClient = await _clientService.CreateClientAsync(client);

                if (createdClient == null) return NotFound();

                return Ok(createdClient);
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("duplicated"))
                {
                    return Conflict(String.Format("El país {0} ya existe.", client.Id));

                }

                return Conflict(ex.Message);
            }
        }

        [HttpGet, ActionName("Get")]
        [Route("GetClientById/{id}")]
        public async Task<ActionResult<IEnumerable<Client>>> GetClientsByIdAsync(Guid id)
        {
            if (id == null) return BadRequest("Id es requerido!");

            var country = await _clientService.GetClientsByIdAsync(id);

            if (country == null) return NotFound();

            return Ok(country);
        }

        [HttpPut, ActionName("Edit")]
        [Route("EditClient")]
        public async Task<ActionResult<Client>> EditClientAsync(Client client)
        {
            try
            {
                var editedClient = await _clientService.EditClientAsync(client);

                return Ok(editedClient);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicated"))
                {
                    return Conflict(String.Format("El cliente {0} ya existe.", client.Id));

                }

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("DeleteClient")]
        public async Task<ActionResult<Client>> DeleteClientAsync(Guid id)
        {
            if (id == null) return BadRequest("Id es requerido");

            var deleteCountry = await _clientService.DeleteClientAsync(id);

            if (deleteCountry == null) return NotFound("Cliente no encontrado");

            return Ok(deleteCountry);
        }
    }
}
