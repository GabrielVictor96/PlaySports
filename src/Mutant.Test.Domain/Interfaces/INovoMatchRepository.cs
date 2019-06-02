using PlaySports.Domain.Commands.NovoMatchCommands;
using PlaySports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaySports.Domain.Interfaces
{
    public interface INovoMatchRepository
    {
        void AddNovoMatch(NovoMatch novoMatch);
        Task<IEnumerable<ListNovoMatchCommand>> ProcurarUsuarioPrimario(string UsuarioPrimario);
        Task<IEnumerable<ListNovoMatchCommand>> ProcurarUsuarioSecundario(string UsuarioSecundario);

    }
}
