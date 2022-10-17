using AutoMapper;
using BaseDeConhecimento.Application.DTOS;
using BaseDeConhecimento.Application.DTOS.Request;
using BaseDeConhecimento.Application.DTOS.Response;
using BaseDeConhecimento.Application.Interfaces;
using BaseDeConhecimento.Domain.Entidades;
using BaseDeConhecimento.Domain.InterfacesDominio;
using BaseDeConhecimento.Domain.Validation;

namespace BaseDeConhecimento.Application.Servicos;

public class ConhecimentoServico : IConhecimentoService
{
    private readonly IServicoDeDominioConhecimento _servicoDeDominioConhecimento;
    private readonly IServicoDeDominioCategoria _servicoDeDominioCategoria;
    private readonly IMapper _mapper;

    public ConhecimentoServico(IMapper mapper, IServicoDeDominioConhecimento servicoDeDominioConhecimento, IServicoDeDominioCategoria servicoDeDominioCategoria)
    {
        _servicoDeDominioConhecimento = servicoDeDominioConhecimento;
        _servicoDeDominioCategoria = servicoDeDominioCategoria;
        _mapper = mapper;
    }



    public async Task<ApiResult<ConhecimentoDTO>> Create(CreateConhecimentoRequestDTO conhecimentoRequest)
    {
        ApiResult<ConhecimentoDTO> apiResult = new ApiResult<ConhecimentoDTO>();

        try
        {
            var conhecimento = _mapper.Map<Conhecimento>(conhecimentoRequest);

            var validationResult = await new ConhecimentoValidator()
                                                .ValidateAsync(conhecimento);

            if (validationResult.IsValid)
            {

                var entity = await _servicoDeDominioConhecimento.Create(conhecimento);
                var conhecimentoDTO = _mapper.Map<ConhecimentoDTO>(entity);
                apiResult.Data = conhecimentoDTO;
                apiResult.Success = true;
                apiResult.Notification = new List<string> { "cadastrado com sucesso" };
            }
            else
            {
                apiResult.Data = null;
                apiResult.Success = false;

                var erros = new List<string>();
                foreach (var item in validationResult.Errors)
                {
                    erros.Add($"Erro na propriedade {item.PropertyName} Erro {item.ErrorMessage}");
                }

                apiResult.Notification = erros;
            }

            return apiResult;
        }
        catch (Exception ex)
        {
            apiResult.Success = false;
            apiResult.Notification = new List<string> { ex.Message };
            return apiResult;
        }
    }

    public async Task<ApiResult<ConhecimentoDTO>> Delete(int id)
    {
        var apiResult = new ApiResult<ConhecimentoDTO>();
        try
        {
            var resultado = await _servicoDeDominioConhecimento.Delete(id);
            apiResult.Data = _mapper.Map<ConhecimentoDTO>(resultado);
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

    public async Task<ApiResult<List<ConhecimentoDTO>>> FindAll()
    {
        var apiResult = new ApiResult<List<ConhecimentoDTO>>();

        try
        {
            var resultado = await _servicoDeDominioConhecimento.FindAll();
            var conhecimentoDTO = new List<ConhecimentoDTO>();
            apiResult.Data = _mapper.Map(resultado, conhecimentoDTO);
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
