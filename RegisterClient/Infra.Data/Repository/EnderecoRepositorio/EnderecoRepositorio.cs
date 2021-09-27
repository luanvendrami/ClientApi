using Domain.Entidades;
using Domain.Interfaces.EnderecoInterface.Repositorio;
using Infra.Data.Context;
using Infra.Data.Repository.BaseRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository.EnderecoRepositorio
{
    class EnderecoRepositorio : Repository<EnderecoEntidade>/*, IEnderecoRepositorio*/
    {
        //Fazer os metodos
        public EnderecoRepositorio(MeuDbContext context) : base(context)
        {

        }

        public void Adicionar(EnderecoEntidade entity)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(EnderecoEntidade entity)
        {
            throw new NotImplementedException();
        }

        public EnderecoEntidade RetornaEnderecoId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FornecedorEntidade> RetornaEnderecoNome(string nome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FornecedorEntidade> RetornaEnderecos()
        {
            throw new NotImplementedException();
        }
    }
}
