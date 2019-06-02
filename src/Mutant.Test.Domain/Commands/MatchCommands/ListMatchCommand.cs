using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Domain.Commands.MatchCommands
{
    public class ListMatchCommand
    {
        public Guid Id { get; set; }
        public string UsuarioCurtiu { get; set; }
        public string UsuarioCurtido { get; set; }
    }
}
