using Domain.Entidades;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class ClientRepository : Repository<ClientEntcs>, IClienteRepository
    {
        public ClientRepository(MeuDbContext context) : base(context)
        {
        }

        public IEnumerable<ClientEntcs> RetornaClientes()
        {
            return _context.Client.AsNoTracking().ToList();
        }

        public IEnumerable<ClientEntcs> RetornaNomeCliente(string nome)
        {
            return _context.Client.Where(n => n.NomeCompleto.Contains(nome)).ToList();
        }

        public ClientEntcs RetornaClientId(int id)
        {
            return _context.Client.AsNoTracking().FirstOrDefault(n => n.Id == id);
        }
    }
}
