using PlaySports.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Domain.Entities
{
    public class Match : Entity
    {
        protected Match() { }

        public Match(string usuarioCurtiu, string usuarioCurtido)
        {
            UsuarioCurtiu = usuarioCurtiu;
            UsuarioCurtido = usuarioCurtido;

        }

        public string UsuarioCurtiu { get; private set; }
        public string UsuarioCurtido { get; private set; }


    }
}
