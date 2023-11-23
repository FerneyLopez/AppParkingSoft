using API_AppParkingSoft.DAL.Entities;
using API_AppParkingSoft.DAL;
using Microsoft.EntityFrameworkCore;
using API_AppParkingSoft.Domain.Interfaces;

namespace API_AppParkingSoft.Domain.Services
{
    public class ClientService : IClientService
    {
        private readonly DataBaseContext _context;
        public ClientService(DataBaseContext context)
        {
            _context = context;
        }

        
        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            var clients = await _context.Clients
              .Include(c => c.Vehicles) 
              .ToListAsync();
            return clients;
        }


        public async Task<Client> CreateClientAsync(Client client)
        {
            try
            {
                client.Id = Guid.NewGuid();

                _context.Clients.Add(client);
                await _context.SaveChangesAsync();

                return client;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Client> GetClientsByIdAsync(Guid id)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Client> EditClientAsync(Client client)
        {
            try
            {

                _context.Clients.Update(client); //El metodo Update sirve para actualizar un objeto
                await _context.SaveChangesAsync();

                return client;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Client> DeleteClientAsync(Guid id)
        {
            try
            {
                var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);

                if (client == null) return null;

                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();

                return client;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

    }
}
