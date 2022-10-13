using BaseDeConhecimento.Application.DTOS.Request;
using BaseDeConhecimento.Application.Interfaces;
using BaseDeConhecimento.Application.Servicos;
using Microsoft.AspNetCore.Mvc;

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

}