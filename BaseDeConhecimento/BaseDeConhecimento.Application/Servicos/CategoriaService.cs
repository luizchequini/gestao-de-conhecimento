using AutoMapper;
using BaseDeConhecimento.Application.DTOS;
using BaseDeConhecimento.Application.DTOS.Request;
using BaseDeConhecimento.Application.DTOS.Response;
using BaseDeConhecimento.Application.Interfaces;
using BaseDeConhecimento.Domain.Entidades;
using BaseDeConhecimento.Domain.InterfacesDominio;

namespace BaseDeConhecimento.Application.Servicos;

public class CategoriaService : ICategoriaService
{
    private readonly IServicoDeDominioCategoria _servicoDeDominioCategoria;
    private readonly IMapper _mapper;

    public CategoriaService(IServicoDeDominioCategoria servicoDeDominioCategoria, IMapper mapper)
    {
        _servicoDeDominioCategoria = servicoDeDominioCategoria;
        _mapper = mapper;
    }

    public async Task<ApiResult<CategoriaDTO>> Create(CreateCategoriaRequestDTO categoriarequest)
    {
        var apiResult = new ApiResult<CategoriaDTO>();
        try
        {

            var entity = _mapper.Map<Categoria>(categoriarequest);


            var resultado = await _servicoDeDominioCategoria.Create(entity);
            apiResult.Data = _mapper.Map<CategoriaDTO>(resultado);
            apiResult.Success = true;

            apiResult.Notification = new List<string> { "cadastrado com sucesso" };
            return apiResult;
        }
        catch (Exception)
        {
            apiResult.Success = false;
            apiResult.Notification = new List<string> { "falhou" };
            return apiResult;
        }
    }

    public async Task<ApiResult<CategoriaDTO>> Delete(int id)
    {
        var apiResult = new ApiResult<CategoriaDTO>();
        try
        {
            var resultado = await _servicoDeDominioCategoria.Delete(id);
            apiResult.Data = _mapper.Map<CategoriaDTO>(resultado);
            apiResult.Success = true;

            apiResult.Notification = new List<string> { "Excluido com sucesso" };
            return apiResult;
        }
        catch (Exception)
        {
            apiResult.Success = false;
            apiResult.Notification = new List<string> { "falhou" };
            return apiResult;
        }
    }

    public async Task<ApiResult<List<CategoriaDTO>>> FindAll()
    {
        var apiResult = new ApiResult<List<CategoriaDTO>>();

        try
        {
            var resultado = await _servicoDeDominioCategoria.FindAll();
            var categoriaDTO = new List<CategoriaDTO>();
            apiResult.Data = _mapper.Map(resultado, categoriaDTO);
            apiResult.Success = true;

            apiResult.Notification = new List<string> { "Retornado com sucesso" };
            return apiResult;
        }
        catch (Exception ex)
        {

            apiResult.Success = false;
            apiResult.Notification = new List<string> { "falhou" + ex.Message };
            return apiResult;
        }
    }

    public async Task<ApiResult<CategoriaDTO>> FindById(int id)
    {
        var apiResult = new ApiResult<CategoriaDTO>();
        try
        {
            var resultado = await _servicoDeDominioCategoria.FindById(id);
            apiResult.Data = _mapper.Map<CategoriaDTO>(resultado);
            apiResult.Success = true;

            apiResult.Notification = new List<string> { "Retornado com sucesso" };
            return apiResult;
        }
        catch (Exception)
        {
            apiResult.Success = false;
            apiResult.Notification = new List<string> { "falhou" };
            return apiResult;
        }
    }

    public async Task<ApiResult<CategoriaDTO>> Update(CreateCategoriaRequestDTO categoriarequest)
    {
        var apiResult = new ApiResult<CategoriaDTO>();
        try
        {
            var entity = _mapper.Map<Categoria>(categoriarequest);

            var resultado = await _servicoDeDominioCategoria.Update(entity);
            apiResult.Data = _mapper.Map<CategoriaDTO>(resultado);
            apiResult.Success = true;

            apiResult.Notification = new List<string> { "Cadastro atualizado com sucesso" };
            return apiResult;
        }
        catch (Exception)
        {
            apiResult.Success = false;
            apiResult.Notification = new List<string> { "falhou" };
            return apiResult;
        }
    }
}
