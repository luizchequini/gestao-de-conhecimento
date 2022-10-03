namespace BaseDeConhecimento.Domain.Entidades;

public class Conhecimento: _Base
{
    public string Assunto  { get; set; }
    public string Conteudo { get; set; }

    public int CategoriaId { get; set; }
    public virtual Categoria Categoria { get; set; }
}
