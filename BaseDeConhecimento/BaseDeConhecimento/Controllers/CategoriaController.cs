using BaseDeConhecimento.Application.DTOS.Request;
using BaseDeConhecimento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BaseDeConhecimento.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaService _CategoriaService;
    public CategoriaController(ICategoriaService categoriaService)
    {
        _CategoriaService = categoriaService;
    }

    [HttpPost("create")]
    public async Task<object> Create(CreateCategoriaRequestDTO request)
    {

        return await _CategoriaService.Create(request);

    }

    [HttpDelete("delete/{id}")]
    public async Task<object> Delete(int id)
    {

        return await _CategoriaService.Delete(id);

    }

    [HttpGet("findbyid/{id}")]
    public async Task<object> FindById(int id)
    {

        return await _CategoriaService.FindById(id);

    }

    [HttpGet("findall")]
    public async Task<object> FindAll()
    {
        return await _CategoriaService.FindAll();
    }

    [HttpPut("update")]
    public async Task<object> Update(CreateCategoriaRequestDTO request)
    {
        return await _CategoriaService.Update(request);
    }
}