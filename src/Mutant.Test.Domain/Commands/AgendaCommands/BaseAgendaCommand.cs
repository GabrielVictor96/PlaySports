using PlaySports.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Domain.Commands.AgendaCommands
{
    public abstract class BaseAgendaCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Criador { get; protected set; }
        public string Membro1 { get; protected set; }
        public string Membro2 { get; protected set; }
        public string Membro3 { get; protected set; }
        public string Membro4 { get; protected set; }
        public string Membro5 { get; protected set; }
        public string Membro6 { get; protected set; }
        public string Membro7 { get; protected set; }
        public string Membro8 { get; protected set; }
        public string Membro9 { get; protected set; }
        public string Atividade { get; protected set; }
        public string Local { get; protected set; }
        public DateTime Data { get; protected set; }
        public string Ativo { get; protected set; }
    }
}
