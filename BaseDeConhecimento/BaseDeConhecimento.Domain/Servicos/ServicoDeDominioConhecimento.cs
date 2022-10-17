using BaseDeConhecimento.Domain.Entidades;
using BaseDeConhecimento.Domain.InterfacesDominio;
using BaseDeConhecimento.Domain.InterfacesRepositorio;
using BaseDeConhecimento.Domain.Util;

namespace BaseDeConhecimento.Domain.Servicos;

public class ServicoDeDominioConhecimento : IServicoDeDominioConhecimento
{
    private readonly IRepositorioConhecimento _repositorioConhecimento;
    private readonly IRepositorioCategoria _repositorioCategoria;

    public ServicoDeDominioConhecimento(IRepositorioConhecimento repositorioConhecimento, IRepositorioCategoria repositorioCategoria)
    {
        _repositorioConhecimento = repositorioConhecimento;
        _repositorioCategoria = repositorioCategoria;
    }

    public async Task<Conhecimento> Create(Conhecimento conhecimento)
    {
        if (conhecimento.Id > 0)
            return await _repositorioConhecimento.Update(conhecimento);
        else
            return await _repositorioConhecimento.Create(conhecimento);
    }

    public Task<Conhecimento> Delete(int id)
    {
        return _repositorioConhecimento.Delete(id);
    }

    public async Task<List<Conhecimento>> FindAll()
    {
        return await _repositorioConhecimento.ListaConhecimento();
    }

    public Task<Conhecimento> FindById(Conhecimento conhecimento)
    {
        throw new NotImplementedException();
    }

    public Task<List<Conhecimento>> FindList(Conhecimento conhecimento)
    {
        throw new NotImplementedException();
    }

    public Task<Conhecimento> Update(Conhecimento conhecimento)
    {
        throw new NotImplementedException();
    }
}
