using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.ClienteInterface.Repositorio
{
    public interface IClienteRepositorio : IRepository<ClienteEntidade>
    {
        IEnumerable<ClienteEntidade> RetornaClientes();
        IEnumerable<ClienteEntidade> RetornaNomeCliente(string nome);
        ClienteEntidade RetornaClientId(int id);
    }
}
