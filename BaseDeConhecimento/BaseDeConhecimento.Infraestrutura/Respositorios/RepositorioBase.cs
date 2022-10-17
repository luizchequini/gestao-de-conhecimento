using BaseDeConhecimento.Domain.InterfacesRepositorio;
using BaseDeConhecimento.Domain.Util;
using BaseDeConhecimento.Infraestrutura.Contexto;
using BaseDeConhecimento.Infraestrutura.Util;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Transactions;

namespace BaseDeConhecimento.Infraestrutura.Respositorios
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        private readonly BaseDeConhecimentoContext _contexto;
        internal DbSet<T> dbset;
        public RepositorioBase(BaseDeConhecimentoContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<T> Create(T obj)
        {
            await _contexto.Set<T>().AddAsync(obj);
            await _contexto.SaveChangesAsync();
            return obj;
        }

        public async Task<T> Delete(int Id)
        {
            var obj = await FindById(Id);
            if (obj is not null)
                _contexto.Set<T>().Remove(obj);
                await _contexto.SaveChangesAsync();

            return obj;
        }

        public async Task<List<T>> FindAll(Expression<Func<T, bool>> predicate)
        {
            return await _contexto.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> FindById(int Id)
        {
            return await _contexto.Set<T>().FindAsync(Id);

        }

        public async Task<List<T>> FindList(Expression expression)
        {
            return await _contexto.Set<T>().ToListAsync();
        }

        public async Task<T> Update(T obj)
        {
            _contexto.Set<T>().Update(obj);
            await _contexto.SaveChangesAsync();
            return obj;
        }

        private IQueryable<T> Query(Expression<Func<T, object>>[] includes)
        {
            var query = includes.Aggregate<Expression<Func<T, object>>, IQueryable<T>>(dbset, (current, expression) => current.Include(expression));
            return (query);
        }

        public async Task<List<T>> Recuperar(Expression<Func<T, bool>> predicate, Include<T> includes, bool somenteLeitura)
        {
            try
            {
                if (somenteLeitura)
                {
                    using (var scope = this.CriarScope())
                    {
                        return await Query(includes.ToArray()).AsNoTracking().Where(predicate).ToListAsync();
                    }
                }
                else
                {
                    return await (this.Query(includes.ToArray()).Where(predicate).ToListAsync());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cria um TransactionScope para leitura de dados não comitados
        /// </summary>
        /// <returns></returns>
        internal TransactionScope CriarScope()
        {
            return (new TransactionScope(TransactionScopeOption.Suppress, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }));
        }
    }
}
