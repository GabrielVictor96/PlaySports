using PlaySports.Domain.Commands.AgendaCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Domain.Validations.Agenda
{
    public class AddAgendaCommandValidation : BaseAgendaCommandValidation<AddAgendaCommand>
    {
        public AddAgendaCommandValidation()
        {
            ValidateCriador();
            ValidateMembro1();
            ValidateMembro2();
            ValidateMembro3();
            ValidateMembro4();
            ValidateMembro5();
            ValidateMembro6();
            ValidateMembro7();
            ValidateMembro8();
            ValidateMembro9();
            ValidateAtividade();
            ValidateLocal();
            ValidateData();
            ValidateAtivo();
        }
    }
}
