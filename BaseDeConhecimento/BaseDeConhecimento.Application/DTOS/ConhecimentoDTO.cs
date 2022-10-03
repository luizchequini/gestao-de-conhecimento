using AutoMapper.Configuration.Annotations;

namespace BaseDeConhecimento.Application.DTOS;

public class ConhecimentoDTO :_BaseDTO
{
    public string Assunto { get; set; }
    public string Conteudo { get; set; }

    public int? CategoriaId { get; set; }
 
    public virtual CategoriaDTO Categoria { get; set; }
}
