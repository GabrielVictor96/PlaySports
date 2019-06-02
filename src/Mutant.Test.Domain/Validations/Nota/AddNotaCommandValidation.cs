using PlaySports.Domain.Commands.NotaCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Domain.Validations.Nota
{
    public class AddNotaCommandValidation : BaseNotaCommandValidation<AddNotaCommand>
    {
        public AddNotaCommandValidation()
        {
            ValidateAgendaId();
            ValidateCriador();
            ValidateNotaMembro1();
            ValidateNotaMembro2();
            ValidateNotaMembro3();
            ValidateNotaMembro4();
            ValidateNotaMembro5();
            ValidateNotaMembro6();
            ValidateNotaMembro7();
            ValidateNotaMembro8();
            ValidateNotaMembro9();

        }
    }
}
