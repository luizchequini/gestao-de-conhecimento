using BaseDeConhecimento.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeConhecimento.Domain.InterfacesDominio;

public interface IServicoDeDominioConhecimento
{
    Task<Conhecimento> Create(Conhecimento conhecimento);
    Task<Conhecimento> Update(Conhecimento conhecimento);
    Task<List<Conhecimento>> FindList(Conhecimento conhecimento);
    Task<Conhecimento> FindById(Conhecimento conhecimento);
    Task<Conhecimento> Delete(Conhecimento conhecimento);
    Task<Categoria> CreateCategoria(Categoria conhecimento);

}
