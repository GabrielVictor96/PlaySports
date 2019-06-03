using PlaySports.Domain.Commands.NotaCommands;
using PlaySports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaySports.Domain.Interfaces
{
    public interface INotaRepository
    {
        void Add(Nota nota);
        Task<ListNotaCommand> GetAtividadeByIdAsync(string atividadeId);
    }
}
