using BaseDeConhecimento.Domain.Entidades;
using BaseDeConhecimento.Domain.InterfacesRepositorio;
using BaseDeConhecimento.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BaseDeConhecimento.Infraestrutura.Respositorios
{
    public class RepositorioConhemento : RepositorioBase<Conhecimento>, IRepositorioConhecimento
    {
        private readonly BaseDeConhecimentoContext _context;
        public RepositorioConhemento(BaseDeConhecimentoContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Conhecimento>> ListaConhecimento()
        {
            var retorno = await _context.Set<Conhecimento>().Include(c => c.Categoria).AsNoTracking().ToListAsync();
            return retorno;
        }
    }
}
