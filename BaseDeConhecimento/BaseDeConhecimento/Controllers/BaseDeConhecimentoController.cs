using BaseDeConhecimento.Application.DTOS.Request;
using BaseDeConhecimento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BaseDeConhecimento.Controllers;

[ApiController]
[Route("[controller]")]
public class BaseDeConhecimentoController : ControllerBase
{
    private readonly IConhecimentoService _ConhecimentoService;
    public BaseDeConhecimentoController(IConhecimentoService ConhecimentoService)
    {
        _ConhecimentoService = ConhecimentoService; 
    }

    [HttpPost("criarconhecimento")]
    public async Task<object> CriarConhecimento( CreateConhecimentoRequestDTO request)
    {

        return await _ConhecimentoService.Create(request);

    }

    [HttpPost("criarcategoria")]
    public async Task<object> CriarCategoria(CreateCategoriaRequestDTO request)
    {

        return await _ConhecimentoService.CreateCategoria(request);

    }

}