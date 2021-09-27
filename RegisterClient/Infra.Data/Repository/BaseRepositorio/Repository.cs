using Domain.Entidades;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository.BaseRepositorio
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly MeuDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(MeuDbContext context) 
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Adicionar(TEntity entity)
        {
            _dbSet.Add(entity);
            SalvarAlteracao();
        }

        public void Atualizar(TEntity entity)
        {
            _dbSet.Update(entity);
            SalvarAlteracao();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public void Remover(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
            SalvarAlteracao();
        }

        public int SalvarAlteracao()
        {
            return _context.SaveChanges();
        }
    }
}
