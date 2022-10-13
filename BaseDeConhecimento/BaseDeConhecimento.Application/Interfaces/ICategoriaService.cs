using BaseDeConhecimento.Application.DTOS.Request;
using BaseDeConhecimento.Application.DTOS.Response;
using BaseDeConhecimento.Application.DTOS;
using System.Linq.Expressions;

namespace BaseDeConhecimento.Application.Interfaces;

public interface ICategoriaService
{
    Task<ApiResult<CategoriaDTO>> Create(CreateCategoriaRequestDTO conhecimentoDTO);
    Task<ApiResult<CategoriaDTO>> Update(CreateCategoriaRequestDTO conhecimentoDTO);
    Task<ApiResult<CategoriaDTO>> FindById(int id);
    Task<ApiResult<List<CategoriaDTO>>> FindAll();
    Task<ApiResult<CategoriaDTO>> Delete(int id);    
}
