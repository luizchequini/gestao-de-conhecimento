using BaseDeConhecimento.Domain.InterfacesRepositorio;
using BaseDeConhecimento.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BaseDeConhecimento.Infraestrutura.Respositorios
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        private readonly BaseDeConhecimentoContext _contexto;

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
    }
}
