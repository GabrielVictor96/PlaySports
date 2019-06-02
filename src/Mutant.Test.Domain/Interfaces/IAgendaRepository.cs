using PlaySports.Domain.Commands.AgendaCommands;
using PlaySports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaySports.Domain.Interfaces
{
    public interface IAgendaRepository
    {
        void Add(Agenda agenda);
        Task<IEnumerable<ListAgendaCommand>> Atividades(string usuario);
        Task<ListAgendaCommand> GetAtividadeByIdAsync(Guid atividadeId);
    }
}
