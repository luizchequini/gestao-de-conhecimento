namespace BaseDeConhecimento.Domain.Entidades;

public class Categoria : _Base
{
    public string Nome { get; set; }
    public string Descricao { get; set; }

    public virtual List<Conhecimento> Conhecimentos { get; set; }
}
