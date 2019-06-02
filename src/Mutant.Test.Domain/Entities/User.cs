using PlaySports.Domain.Core.Entities;
using System;
using PlaySports.Domain.Core.Enums;
using PlaySports.Domain.Core.ValueObjects;

namespace PlaySports.Domain.Entities
{
    public class User : Entity
    {
        protected User() { }

        public User(string nome, Sexo sexo, string login, string esporte, string nivel, string localizacao, DateTime dataNascimento, byte[] imagem)
        {
            Nome = nome;
            Sexo = sexo;
            Login = login;
            DataNascimento = dataNascimento;
            Esporte = esporte;
            Nivel = nivel;
            Localizacao = localizacao;
            Imagem = imagem;
        }

        public string Nome { get; private set; }
        public Sexo Sexo { get; private set; }
        public string Login { get; private set; }
        public string Esporte { get; private set; }
        public string Nivel { get; private set; }
        public string Localizacao { get; private set; }
        public Password Senha { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public byte[] Imagem { get; private set; }

        public void FillPassword(string text) => Senha = new Password(text);
    }
}