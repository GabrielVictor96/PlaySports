using PlaySports.Domain.Core.Commands;
using PlaySports.Domain.Core.ValueObjects;
using PlaySports.Domain.Validations.AuthenticationValidations;

namespace PlaySports.Domain.Commands.AuthenticationCommands
{
    public class LoginCommand : Command
    {
        public LoginCommand(string login, Password senha)
        {
            Login = login;
            Senha = senha;
        }

        public string Login { get; private set; }
        public Password Senha { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new LoginCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}