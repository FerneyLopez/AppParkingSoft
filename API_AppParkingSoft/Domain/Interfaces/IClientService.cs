using API_AppParkingSoft.DAL.Entities;

namespace API_AppParkingSoft.Domain.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client> CreateClientAsync(Client client);
        Task<Client> GetClientsByIdAsync(Guid id);
        Task<Client> EditClientAsync(Client client);
        Task<Client> DeleteClientAsync(Guid id);
    }
}
