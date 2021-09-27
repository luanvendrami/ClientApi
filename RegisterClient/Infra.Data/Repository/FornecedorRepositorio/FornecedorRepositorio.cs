using Domain.Entidades;
using Domain.Interfaces.FornecedorInterface.Repositorio;
using Infra.Data.Context;
using Infra.Data.Repository.BaseRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository.FornecedorRepositorio
{
    //Fazer os metodos
    public class FornecedorRepositorio : Repository<FornecedorEntidade>, IFornecedorRepositorio
    {
        public FornecedorRepositorio(MeuDbContext context) : base(context)
        {
        }
        public IEnumerable<FornecedorEntidade> RetornaFornecedores()
        {
            throw new NotImplementedException();
        }

        public FornecedorEntidade RetornaFornecedorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FornecedorEntidade> RetornaNomeFornecedor(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
