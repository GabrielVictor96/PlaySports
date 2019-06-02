using PlaySports.Domain.Validations.MatchValidations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Domain.Commands.MatchCommands
{
    public class AddMatchCommand : BaseMatchCommand
    {
        public AddMatchCommand(string usuarioCurtiu, string usuarioCurtido)
        {
            UsuarioCurtiu = usuarioCurtiu;
            UsuarioCurtido = usuarioCurtido;

        }

        public override bool IsValid()
        {
            ValidationResult = new AddMatchCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
