using Domain.Entidades;
using Domain.Interfaces;
using Domain.Interfaces.ClienteInterface.Repositorio;
using Infra.Data.Context;
using Infra.Data.Repository.BaseRepositorio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.Repository.ClienteRepositorio
{
    public class ClienteRepositorio : Repository<ClienteEntidade>, IClienteRepositorio
    {
        public ClienteRepositorio(MeuDbContext context) : base(context)
        {
        }

        public IEnumerable<ClienteEntidade> RetornaClientes()
        {
            return _context.Cliente.AsNoTracking().ToList();
        }

        public IEnumerable<ClienteEntidade> RetornaNomeCliente(string nome)
        {
            return _context.Cliente.Where(n => n.NomeCompleto.Contains(nome)).ToList();
        }

        public ClienteEntidade RetornaClientId(int id)
        {
            return _context.Cliente.AsNoTracking().FirstOrDefault(n => n.Id == id);
        }
    }
}
