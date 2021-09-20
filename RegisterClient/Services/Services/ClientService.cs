using Domain.Entidades;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Services.Services
{
    public class ClientService : IClientService
    {

        private readonly IClienteRepository _clienteRepository;

        public ClientService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IEnumerable<ClientEntcs> RetornoLista()
        {
            return _clienteRepository.RetornaClientes();
        }
        public IEnumerable<ClientEntcs> RetornaListaNomes(string nome)
        {
            return _clienteRepository.RetornaNomeCliente(nome);
        }

        public ClientEntcs RetornaIdCliente(int id)
        {
            return _clienteRepository.RetornaClientId(id);
        }

        public void SalvarCliente(ClientDto dto)
        {
            var cliente = new ClientEntcs();
            cliente.NomeCompleto = dto.NomeCompleto;
            cliente.Cpf = dto.Cpf;
            cliente.Rg = dto.Rg;
            cliente.DataNascimento = dto.DataNascimento;
            cliente.Cep = dto.Cep;

            _clienteRepository.Adicionar(cliente);
        }

        public void Atualizar(ClientDto dto)
        {
            var cliente = new ClientEntcs();
            cliente.NomeCompleto = dto.NomeCompleto;
            cliente.Cpf = dto.Cpf;
            cliente.Rg = dto.Rg;
            cliente.DataNascimento = dto.DataNascimento;
            cliente.Cep = dto.Cep;

            _clienteRepository.Atualizar(cliente);
        }

        public bool DeletarCliente(int id)
        {
            try
            {
                _clienteRepository.Remover(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
