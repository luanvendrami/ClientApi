using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.FornecedorInterface.Repositorio
{
    public interface IFornecedorRepositorio : IRepository<FornecedorEntidade>
    {
        IEnumerable<FornecedorEntidade> RetornaFornecedores();
        IEnumerable<FornecedorEntidade> RetornaNomeFornecedor(string nome);
        FornecedorEntidade RetornaFornecedorId(int id);
    }
}
