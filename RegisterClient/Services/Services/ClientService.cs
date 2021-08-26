using Domain.Entidades;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ClientService : IClientService
    {

        private readonly MeuDbContext _context;

        public ClientService(MeuDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClientDto>> GetClients()
        {
            try
            {
                return await _context.Client.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ClientDto>> GetClientByNome(string nome)
        {
            IEnumerable<ClientDto> clients;
            if (!string.IsNullOrWhiteSpace(nome))
            {
                clients = await _context.Client.Where(n => n.NomeCompleto.Contains(nome)).ToListAsync();
            }
            else
            {
                clients = await GetClients();
            }
            return clients;
        }

        public async Task<ClientDto> GetClient(int id)
        {
            var client = await _context.Client.FindAsync(id);
            return client;
        }

        public async Task CreateClient(ClientDto client)
        {
            _context.Client.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClient(ClientDto client)
        {
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClient(ClientDto client)
        {
            _context.Client.Remove(client);
            await _context.SaveChangesAsync();
        }  
    }
}
