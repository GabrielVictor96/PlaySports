using System;
using PlaySports.Domain.Core.Enums;

namespace PlaySports.Domain.Commands.UserCommands
{
    public class ListUserCommand
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Sexo Sexo { get; set; }
        public string Login { get; set; }
        public string Esporte { get; set; }
        public string Nivel { get; set; }
        public string Localizacao { get; set; }
        public DateTime DataNascimento { get; set; }
        public byte[] Imagem { get; set; }
        public string Denuncia { get; set; }
    }
}