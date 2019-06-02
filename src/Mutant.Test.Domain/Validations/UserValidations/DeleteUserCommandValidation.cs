using PlaySports.Domain.Commands.UserCommands;

namespace PlaySports.Domain.Validations.UserValidations
{
    public class DeleteUserCommandValidation : BaseUserCommandValidation<DeleteUserCommand>
    {
        public DeleteUserCommandValidation()
        {
            ValidateId();
        }
    }
}