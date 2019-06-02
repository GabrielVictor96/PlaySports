using PlaySports.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaySports.Application.Interfaces
{
    public interface IAgendaAppService
    {
        void Add(AgendaViewModel agendaViewModel);
        Task<IEnumerable<AgendaViewModel>> Atividades(string usuario);
        Task<AgendaViewModel> GetAtividadeByIdAsync(Guid atividadeId);
        object Edit(Guid atividadeId, string inativar);
    }
}
