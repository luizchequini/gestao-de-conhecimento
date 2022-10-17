using BaseDeConhecimento.Domain.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeConhecimento.Domain.InterfacesRepositorio
{
    public interface IRepositorioBase<T> where T : class
    {
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task<T> Delete(int Id);
        Task<T> FindById(int Id);
        Task<List<T>> FindAll(Expression<Func<T, bool>> predicate);
        Task <List<T>> Recuperar(Expression<Func<T, bool>> predicate, Include<T> includes, bool somenteLeitura = false);
    }
}
