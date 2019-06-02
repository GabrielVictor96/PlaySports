using PlaySports.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Domain.Commands.NovoMatchCommands
{
    public abstract class BaseNovoMatchCommand : Command
    {
        public Guid Id { get; protected set; }
        public string UsuarioPrimario { get; protected set; }
        public string UsuarioSecundario { get; protected set; }

    }
}
