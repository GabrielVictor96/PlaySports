using System;
using PlaySports.Domain.Core.Commands;
using PlaySports.Domain.Core.Enums;

namespace PlaySports.Domain.Commands.UserCommands
{
    public abstract class BaseUserCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public Sexo Sexo { get; protected set; }
        public string Login { get; protected set; }
        public string Esporte { get; protected set; }
        public string Nivel { get; protected set; }
        public string Localizacao { get; protected set; }
        public string Senha { get; protected set; }
        public string ConfirmarSenha { get; protected set; }
        public DateTime DataNascimento { get; protected set; }
        public byte[] Imagem { get; protected set; }
        public string Denuncia { get; protected set; }
    }
}