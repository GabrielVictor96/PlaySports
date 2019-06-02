using FluentValidation;
using PlaySports.Domain.Validations.NovoMatchValidations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Domain.Commands.NovoMatchCommands
{
    public class AddNovoMatchCommand : BaseNovoMatchCommand
    {
        public AddNovoMatchCommand(string usuarioPrimario, string usuarioSecundario)
        {
            UsuarioPrimario = usuarioPrimario;
            UsuarioSecundario = usuarioSecundario;

        }

        public override bool IsValid()
        {
            ValidationResult = new AddNovoMatchCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
