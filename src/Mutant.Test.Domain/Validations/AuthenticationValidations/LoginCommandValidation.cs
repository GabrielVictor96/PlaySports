using FluentValidation;
using PlaySports.Domain.Commands.AuthenticationCommands;

namespace PlaySports.Domain.Validations.AuthenticationValidations
{
    public class LoginCommandValidation : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidation()
        {
            RuleFor(x => x.Login)
                .NotNull()
                .NotEmpty().WithMessage("O login é de preenchimento obrigatório.");

            RuleFor(x => x.Senha)
                .NotNull()
                .NotEmpty().WithMessage("Preencha sua senha.");
        }
    }
}