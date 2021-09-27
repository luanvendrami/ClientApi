using Domain.Entidades;
using Domain.Interfaces.ClienteInterface.Repositorio;
using Domain.Interfaces.ClienteInterface.Service;
using System.Collections.Generic;

namespace Services.Services
{
    public class ClienteService : IClienteService
    {

        private readonly IClienteRepositorio _clienteRepository;

        public ClienteService(IClienteRepositorio clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IEnumerable<ClienteEntidade> RetornoLista()
        {
            return _clienteRepository.RetornaClientes();
        }
        public IEnumerable<ClienteEntidade> RetornaListaNomes(string nome)
        {
            return _clienteRepository.RetornaNomeCliente(nome);
        }

        public ClienteEntidade RetornaIdCliente(int id)
        {
            return _clienteRepository.RetornaClientId(id);
        }

        public void SalvarCliente(ClienteDto dto)
        {
            var cliente = new ClienteEntidade
            {
                NomeCompleto = dto.NomeCompleto,
                Cpf = dto.Cpf,
                Rg = dto.Rg,
                DataNascimento = dto.DataNascimento
            };

            _clienteRepository.Adicionar(cliente);
        }

        public void Atualizar(ClienteDto dto)
        {
            var cliente = new ClienteEntidade
            {
                NomeCompleto = dto.NomeCompleto,
                Cpf = dto.Cpf,
                Rg = dto.Rg,
                DataNascimento = dto.DataNascimento,
                Cep = dto.Cep
            };

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
