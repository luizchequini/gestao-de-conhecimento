using BaseDeConhecimento.Domain.Entidades;
using BaseDeConhecimento.Domain.InterfacesDominio;
using BaseDeConhecimento.Domain.InterfacesRepositorio;
using System.Linq.Expressions;

namespace BaseDeConhecimento.Domain.Servicos;

public class ServicoDeDominioCategoria : IServicoDeDominioCategoria
{
    private readonly IRepositorioCategoria _repositorioCategoria;

    public ServicoDeDominioCategoria(IRepositorioCategoria repositorioCategoria)
    {
        _repositorioCategoria = repositorioCategoria;
    }

    public async Task<Categoria> Create(Categoria categoria)
    {
        if (categoria.Id > 0)
            return await _repositorioCategoria.Update(categoria);
        else
            return await _repositorioCategoria.Create(categoria);
    }

    public Task<Categoria> Delete(int id)
    {
        return _repositorioCategoria.Delete(id);
    }

    public async Task<Categoria> FindById(Categoria categoria)
    {
        return await _repositorioCategoria.FindById(categoria.Id);
    }

    public async Task<Categoria> FindById(int id)
    {
        return await _repositorioCategoria.FindById(id);
    }

    public async Task<List<Categoria>> FindAll()
    {
        return await _repositorioCategoria.FindAll(x =>x.Id > 0);
    }

    public Task<List<Categoria>> FindList(Categoria categoria)
    {
        throw new NotImplementedException();
    }

    public async Task<Categoria> Update(Categoria categoria)
    {
        return await _repositorioCategoria.Update(categoria);
    }
}
