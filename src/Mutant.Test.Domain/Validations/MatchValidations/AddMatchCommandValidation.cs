using PlaySports.Domain.Commands.MatchCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Domain.Validations.MatchValidations
{
    public class AddMatchCommandValidation : BaseMatchCommandValidation<AddMatchCommand>
    {
        public AddMatchCommandValidation()
        {
            ValidateUsuarioCurtiu();
            ValidateUsuarioCurtido();

        }
    }
}
