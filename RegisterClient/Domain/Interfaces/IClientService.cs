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
        IEnumerable<ClientEntcs> RetornoLista();
        void SalvarCliente(ClientDto dto);
        IEnumerable<ClientEntcs> RetornaListaNomes(string nome);
        ClientEntcs RetornaIdCliente(int id);
        bool DeletarCliente(int id);
    }
}
