using BaseDeConhecimento.Domain.Entidades;
using BaseDeConhecimento.Domain.InterfacesRepositorio;
using BaseDeConhecimento.Infraestrutura.Contexto;
using System.Linq.Expressions;

namespace BaseDeConhecimento.Infraestrutura.Respositorios
{
    public class RepositorioConhemento : RepositorioBase<Conhecimento>, IRepositorioConhecimento
    {
        public RepositorioConhemento(BaseDeConhecimentoContext dbContext) : base(dbContext)
        {

        }
         
    }
}
