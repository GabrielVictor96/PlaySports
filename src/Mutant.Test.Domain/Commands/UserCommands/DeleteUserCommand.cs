using System;
using PlaySports.Domain.Validations.UserValidations;

namespace PlaySports.Domain.Commands.UserCommands
{
    public class DeleteUserCommand : BaseUserCommand
    {
        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}