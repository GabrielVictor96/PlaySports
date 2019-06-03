using PlaySports.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaySports.Application.Interfaces
{
    public interface INotaAppService
    {
        void Add(NotaViewModel notaViewModel);
        Task<NotaViewModel> GetAtividadeByIdAsync(string atividadeId);

    }
}
