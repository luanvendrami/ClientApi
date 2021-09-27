using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.ClienteInterface.Service
{
    public interface IClienteService
    {
        IEnumerable<ClienteEntidade> RetornoLista();
        void SalvarCliente(ClienteDto dto);
        void Atualizar(ClienteDto dto);
        IEnumerable<ClienteEntidade> RetornaListaNomes(string nome);
        ClienteEntidade RetornaIdCliente(int id);
        bool DeletarCliente(int id);
    }
}
