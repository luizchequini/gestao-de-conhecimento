using BaseDeConhecimento.Domain.Entidades;
using BaseDeConhecimento.Domain.InterfacesRepositorio;
using BaseDeConhecimento.Infraestrutura.Contexto;
using System.Linq.Expressions;

namespace BaseDeConhecimento.Infraestrutura.Respositorios
{
    public class RepositorioCategoria : RepositorioBase<Categoria>, IRepositorioCategoria
    {
        public RepositorioCategoria(BaseDeConhecimentoContext dbContext) : base(dbContext)
        {

        }

        
    }
}
