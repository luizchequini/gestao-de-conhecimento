using BaseDeConhecimento.Application.DTOS;
using BaseDeConhecimento.Application.DTOS.Request;
using BaseDeConhecimento.Application.DTOS.Response;
using BaseDeConhecimento.Application.Interfaces;
using BaseDeConhecimento.Application.Servicos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BaseDeConhecimento.Controllers;

[ApiController]
[Route("[controller]")]
public class ConhecimentoController : ControllerBase
{
    private readonly IConhecimentoService _ConhecimentoService;

    public ConhecimentoController(IConhecimentoService ConhecimentoService)
    {
        _ConhecimentoService = ConhecimentoService;
    }

    [HttpPost("create")]
    public async Task<object> Create(CreateConhecimentoRequestDTO request)
    {

        return await _ConhecimentoService.Create(request);

    }

    [HttpDelete("{id}")]
    public async Task<object> Delete(int id)
    {
        return await _ConhecimentoService.Delete(id);
    }

    [HttpGet("findall")]
    public async Task<ApiResult<List<ConhecimentoDTO>>> FindAll()
    {
        var retorno = await _ConhecimentoService.FindAll();

        return retorno;
    }

    [HttpPut("update")]
    public async Task<object> Update(CreateConhecimentoRequestDTO request)
    {
        return await _ConhecimentoService.Update(request);
    }
}