namespace BaseDeConhecimento.Application.DTOS.Request;

public class CreateConhecimentoRequestDTO :_BaseDTO
{
    public string Assunto { get; set; }
    public string Conteudo { get; set; } 
    public int? CategoriaId { get; set; }
     
}
