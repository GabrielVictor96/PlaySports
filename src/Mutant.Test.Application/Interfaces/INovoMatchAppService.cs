using PlaySports.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaySports.Application.Interfaces
{
    public interface INovoMatchAppService
    {
        void AddNovoMatch(NovoMatchViewModel novoMatchViewModel);
        Task<IEnumerable<NovoMatchViewModel>> ProcurarUsuarioPrimario(string UsuarioPrimario);
        Task<IEnumerable<NovoMatchViewModel>> ProcurarUsuarioSecundario(string UsuarioSecundario);
    }
}
