using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlaySports.Domain.Commands.MatchCommands;
using PlaySports.Domain.Entities;

namespace PlaySports.Domain.Interfaces
{
    public interface IMatchRepository
    {
        void AddMatch(Match match);
        ListMatchCommand ProcurarMatch(string usuarioCurtiu, string usuarioCurtido);
    }
}
