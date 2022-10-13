using BaseDeConhecimento.Domain.Entidades;
using FluentValidation;

namespace BaseDeConhecimento.Domain.Validation;

public class ConhecimentoValidator: AbstractValidator<Conhecimento>
{
	public ConhecimentoValidator()
	{
		//Validação para categoria nula
		RuleFor(x => x.CategoriaId)
			.NotNull().NotEmpty().WithMessage("Este campo é obrigatório!");
	}
}
