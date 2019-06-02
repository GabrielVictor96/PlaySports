using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlaySports.Application.ViewModels;

namespace PlaySports.Application.Interfaces
{
    public interface IMatchAppService
    {
        void AddMatch(MatchViewModel matchViewModel);
        MatchViewModel ProcurarMatch(string usuarioCurtiu, string usuarioCurtido);
    }
}
