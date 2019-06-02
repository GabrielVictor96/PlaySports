using PlaySports.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Domain.Entities
{
    public class NovoMatch : Entity
    {
        protected NovoMatch() { }

        public NovoMatch(string usuarioPrimario, string usuarioSecundario)
        {
            UsuarioPrimario = usuarioPrimario;
            UsuarioSecundario = usuarioSecundario;

        }

        public string UsuarioPrimario { get; private set; }
        public string UsuarioSecundario { get; private set; }


    }
}
