using BaseDeConhecimento.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeConhecimento.Domain.InterfacesDominio;

public interface IServicoDeDominioCategoria
{
    Task<Categoria> Create(Categoria categoria);
    Task<Categoria> Update(Categoria categoria);
    Task<List<Categoria>> FindList(Categoria categoria);
    Task<Categoria> FindById(Categoria categoria);
    Task<Categoria> FindById(int id);
    Task<List<Categoria>> FindAll();
    Task<Categoria> Delete(int id);
}
