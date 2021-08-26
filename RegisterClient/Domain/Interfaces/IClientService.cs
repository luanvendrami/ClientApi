using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetClients();
        Task<ClientDto> GetClient(int id);
        Task<IEnumerable<ClientDto>> GetClientByNome(string nome);
        Task CreateClient(ClientDto client);
        Task UpdateClient(ClientDto client);
        Task DeleteClient(ClientDto client);
    }
}
