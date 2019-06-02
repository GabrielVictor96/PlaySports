using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Domain.Commands.NovoMatchCommands
{
    public class ListNovoMatchCommand
    {
        public Guid Id { get; set; }
        public string UsuarioPrimario { get; set; }
        public string UsuarioSecundario { get; set; }

    }
}
