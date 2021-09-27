using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.EnderecoInterface.Repositorio
{
    public interface IEnderecoRepositorio : IRepository<EnderecoEntidade>
    {
        IEnumerable<EnderecoEntidade> RetornaEnderecos();
        IEnumerable<EnderecoEntidade> RetornaEnderecoNome(string nome);
        EnderecoEntidade RetornaEnderecoId(int id);
    }
}
