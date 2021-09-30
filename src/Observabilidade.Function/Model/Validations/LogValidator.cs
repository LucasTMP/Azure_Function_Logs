using FluentValidation;

namespace Observabilidade.Function.Model.Validations
{
    public class LogValidator : AbstractValidator<Log>
    {
        public LogValidator()
        {
            RuleFor(log => log.NomeAplicacao)
                .NotEmpty().WithMessage("Nome obrigatório")
                .Length(5, 50).WithMessage("O Nome deve conter no mínimo 5 e no máximo 50 caracteres");

            RuleFor(log => log.Mensagem)
                .NotEmpty().WithMessage("O campo mensagem não pode ser vazio")
                .Length(10, 250).WithMessage("A Mensagem deve ter no mínimo 10 e no máximo 250 caracteres");

            RuleFor(log => log.Detalhe)
                .MaximumLength(1000).WithMessage("O Detalhe deve ter no máximo 1000 caracteres");
        }
    }
}
