using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClienteRepository : IRepository<ClientEntcs>
    {
        IEnumerable<ClientEntcs> RetornaClientes();
        IEnumerable<ClientEntcs> RetornaNomeCliente(string nome);
        ClientEntcs RetornaClientId(int id);
    }
}
