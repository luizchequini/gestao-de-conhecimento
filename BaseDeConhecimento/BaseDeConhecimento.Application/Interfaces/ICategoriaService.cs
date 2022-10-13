using BaseDeConhecimento.Application.DTOS.Request;
using BaseDeConhecimento.Application.DTOS.Response;
using BaseDeConhecimento.Application.DTOS;

namespace BaseDeConhecimento.Application.Interfaces;

public interface ICategoriaService
{
    Task<ApiResult<CategoriaDTO>> Create(CreateCategoriaRequestDTO conhecimentoDTO);
    Task<ApiResult<CategoriaDTO>> Update(CreateCategoriaRequestDTO conhecimentoDTO);
    Task<ApiResult<CategoriaDTO>> Update(int id);
    Task<ApiResult<List<CategoriaDTO>>> FindList(CategoriaDTO conhecimentoDTO);
    Task<ApiResult<CategoriaDTO>> FindById(CategoriaDTO conhecimentoDTO);
    Task<ApiResult<CategoriaDTO>> FindById(int id);
    Task<ApiResult<CategoriaDTO>> Delete(CategoriaDTO conhecimentoDTO);
    Task<ApiResult<CategoriaDTO>> Delete(int id);
}
