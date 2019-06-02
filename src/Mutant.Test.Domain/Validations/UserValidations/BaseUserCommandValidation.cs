using FluentValidation;
using PlaySports.Domain.Commands.UserCommands;

namespace PlaySports.Domain.Validations.UserValidations
{
    public class BaseUserCommandValidation<T> : AbstractValidator<T> where T : BaseUserCommand
    {
        private string MaximumLengthMessage(int value) => $"Quantidade de caracteres permitida ultrapassado. Limite permitido: {value}";

        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("O id é de preenchimento obrigatório.");
        }

        protected void ValidateName()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty().WithMessage("O nome é de preenchimento obrigatório.")
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateBirthdayDate()
        {
            RuleFor(x => x.DataNascimento)
                .NotNull()
                .NotEmpty().WithMessage("A data de nascimento é de preenchimento obrigatório.");
        }

        protected void ValidateLogin()
        {
            RuleFor(x => x.Login)
                .NotNull()
                .NotEmpty().WithMessage("O login é de preenchimento obrigatório.")
                .MaximumLength(60).WithMessage(MaximumLengthMessage(60));
        }

        protected void ValidatePassword()
        {
            RuleFor(x => x.Senha)
                .NotNull()
                .NotEmpty().WithMessage("A senha é de preenchimento obrigatório.")
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ConfirmPassword()
        {
            RuleFor(x => x.Senha)
                .Equal(x => x.ConfirmarSenha)
                .WithMessage("A senha e confirmação da senha devem ser idênticas");
        }
    }
}