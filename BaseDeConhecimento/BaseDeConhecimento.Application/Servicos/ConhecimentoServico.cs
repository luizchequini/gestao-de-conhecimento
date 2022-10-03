using AutoMapper;
using BaseDeConhecimento.Application.DTOS;
using BaseDeConhecimento.Application.DTOS.Request;
using BaseDeConhecimento.Application.DTOS.Response;
using BaseDeConhecimento.Application.Interfaces;
using BaseDeConhecimento.Domain.Entidades;
using BaseDeConhecimento.Domain.InterfacesDominio;

namespace BaseDeConhecimento.Application.Servicos;

public class ConhecimentoServico : IConhecimentoService
{
    private readonly IServicoDeDominioConhecimento _servicoDeDominioConhecimento;
    private readonly IMapper _mapper;

    public ConhecimentoServico(IMapper mapper, IServicoDeDominioConhecimento servicoDeDominioConhecimento)
    {
        _servicoDeDominioConhecimento = servicoDeDominioConhecimento;
        _mapper = mapper;
    }
    
    
    
    public async Task<ApiResult<ConhecimentoDTO>> Create(CreateConhecimentoRequestDTO conhecimentoRequest)
    {
        ApiResult<ConhecimentoDTO> apiResult = new ApiResult<ConhecimentoDTO>();

        try
        {
            var conhecimento = _mapper.Map<Conhecimento>(conhecimentoRequest);

           var entity = await _servicoDeDominioConhecimento.Create(conhecimento);

            var conhecimentoDTO = _mapper.Map<ConhecimentoDTO>(entity);
            apiResult.Data = conhecimentoDTO;
            apiResult.Success = true;
             
            apiResult.Notification = new List<string> { "cadastrado com sucesso" };
            return apiResult;
        }
        catch (Exception)
        { 
            apiResult.Success = false;
            apiResult.Notification = new List<string> { "falhou"};
            return apiResult;
        }
    }

    public async Task<ApiResult<CategoriaDTO>> CreateCategoria(CreateCategoriaRequestDTO categoriarequest)
    {
        var apiResult = new ApiResult<CategoriaDTO>();
        try
        { 

         var entity = _mapper.Map<Categoria>(categoriarequest);
             

            var resultado = await _servicoDeDominioConhecimento.CreateCategoria(entity);
            apiResult.Data = _mapper.Map<CategoriaDTO>(resultado); ;
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

  
    public Task<ApiResult<ConhecimentoDTO>> Delete(ConhecimentoDTO conhecimentoDTO)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResult<ConhecimentoDTO>> FindById(ConhecimentoDTO conhecimentoDTO)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResult<List<ConhecimentoDTO>>> FindList(ConhecimentoDTO conhecimentoDTO)
    {
        throw new NotImplementedException();
    }

    public Task<ConhecimentoDTO> Update(ConhecimentoDTO conhecimentoDTO)
    {
        throw new NotImplementedException();
    }
}
