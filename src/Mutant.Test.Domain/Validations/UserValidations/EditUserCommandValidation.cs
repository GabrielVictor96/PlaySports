using PlaySports.Domain.Commands.UserCommands;

namespace PlaySports.Domain.Validations.UserValidations
{
    public class EditUserCommandValidation : BaseUserCommandValidation<EditUserCommand>
    {
        public EditUserCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateLogin();
            ValidateBirthdayDate();
        }
    }
}