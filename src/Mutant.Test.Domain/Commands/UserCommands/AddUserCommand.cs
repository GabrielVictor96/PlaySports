using System;
using PlaySports.Domain.Core.Enums;
using PlaySports.Domain.Validations.UserValidations;

namespace PlaySports.Domain.Commands.UserCommands
{
    public class AddUserCommand : BaseUserCommand
    {
        public AddUserCommand(string nome, Sexo sexo, string login, string esporte, string nivel, string localizacao, string senha, string confirmarSenha, DateTime dataNascimento, byte[] imagem)
        {
            Nome = nome;
            Sexo = sexo;
            Login = login;
            Esporte = esporte;
            Nivel = nivel;
            Localizacao = localizacao;
            Senha = senha;
            ConfirmarSenha = confirmarSenha;
            DataNascimento = dataNascimento;
            Imagem = imagem;
        }
        
        public override bool IsValid()
        {
            ValidationResult = new AddUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}