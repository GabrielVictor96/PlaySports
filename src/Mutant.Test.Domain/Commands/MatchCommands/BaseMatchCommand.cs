using PlaySports.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Domain.Commands.MatchCommands
{
    public abstract class BaseMatchCommand : Command
    {
        public Guid Id { get; protected set; }
        public string UsuarioCurtiu { get; protected set; }
        public string UsuarioCurtido { get; protected set; }
        
    }
}
