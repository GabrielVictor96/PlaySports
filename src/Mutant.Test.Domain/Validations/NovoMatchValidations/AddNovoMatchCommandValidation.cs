using PlaySports.Domain.Commands.NovoMatchCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Domain.Validations.NovoMatchValidations
{
    public class AddNovoMatchCommandValidation : BaseNovoMatchCommandValidation<AddNovoMatchCommand>
    {
        public AddNovoMatchCommandValidation()
        {
            ValidateUsuarioPrimario();
            ValidateUsuarioSecundario();

        }
    }
}
