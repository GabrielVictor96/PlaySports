using PlaySports.Domain.Validations.Nota;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Domain.Commands.NotaCommands
{
    public class AddNotaCommand : BaseNotaCommand
    {
        public AddNotaCommand(string agendaId, string criador, string notaMembro1, string notaMembro2, string notaMembro3, string notaMembro4, string notaMembro5, string notaMembro6, string notaMembro7, string notaMembro8, string notaMembro9)
        {
            AgendaId = agendaId;
            Criador = criador;
            NotaMembro1 = notaMembro1;
            NotaMembro2 = notaMembro2;
            NotaMembro3 = notaMembro3;
            NotaMembro4 = notaMembro4;
            NotaMembro5 = notaMembro5;
            NotaMembro6 = notaMembro6;
            NotaMembro7 = notaMembro7;
            NotaMembro8 = notaMembro8;
            NotaMembro9 = notaMembro9;

        }

        public override bool IsValid()
        {
            ValidationResult = new AddNotaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
