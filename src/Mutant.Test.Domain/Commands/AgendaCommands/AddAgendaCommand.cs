using PlaySports.Domain.Validations.Agenda;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Domain.Commands.AgendaCommands
{
    public class AddAgendaCommand : BaseAgendaCommand
    {
        public AddAgendaCommand(string criador, string membro1, string membro2, string membro3, string membro4, string membro5, string membro6, string membro7, string membro8, string membro9, string atividade, string local, DateTime data, string ativo)
        {
            Criador = criador;
            Membro1 = membro1;
            Membro2 = membro2;
            Membro3 = membro3;
            Membro4 = membro4;
            Membro5 = membro5;
            Membro6 = membro6;
            Membro7 = membro7;
            Membro8 = membro8;
            Membro9 = membro9;
            Atividade = atividade;
            Local = local;
            Data = data;
            Ativo = ativo; 
        }

        public override bool IsValid()
        {
            ValidationResult = new AddAgendaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
