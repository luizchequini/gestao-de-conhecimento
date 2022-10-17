using BaseDeConhecimento.Application.DTOS;
using BaseDeConhecimento.Application.DTOS.Request;
using BaseDeConhecimento.Application.DTOS.Response;

namespace BaseDeConhecimento.Application.Interfaces;

public interface IConhecimentoService
{
    Task<ApiResult<ConhecimentoDTO>> Create(CreateConhecimentoRequestDTO conhecimentoDTO);
    Task<ConhecimentoDTO> Update(ConhecimentoDTO conhecimentoDTO);
    Task<ApiResult<List<ConhecimentoDTO>>> FindList(ConhecimentoDTO conhecimentoDTO);
    Task<ApiResult<ConhecimentoDTO>> FindById(ConhecimentoDTO conhecimentoDTO);
    Task<ApiResult<ConhecimentoDTO>> Delete(int id);
    Task<ApiResult<List<ConhecimentoDTO>>> FindAll();
}
