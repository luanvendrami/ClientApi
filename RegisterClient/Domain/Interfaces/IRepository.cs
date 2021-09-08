using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class, new()
    {
        void Adicionar(T entity);
        void Atualizar(T entity);
        void Remover(int id);
        int SalvarAlteracao();
    }
}
