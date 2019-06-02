using PlaySports.Domain.Commands.UserCommands;

namespace PlaySports.Domain.Validations.UserValidations
{
    public class AddUserCommandValidation : BaseUserCommandValidation<AddUserCommand>
    {
        public AddUserCommandValidation()
        {
            ValidateName();
            ValidateLogin();
            ValidatePassword();
            ValidateBirthdayDate();
            ConfirmPassword();
        }
    }
}