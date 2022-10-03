namespace BaseDeConhecimento.Application.DTOS;

public class CategoriaDTO:_BaseDTO
{
    public string Nome { get; set; }
    public string Descricao { get; set; }

    public virtual List<ConhecimentoDTO> Conhecimentos { get; set; }
}
