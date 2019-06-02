using System;
using PlaySports.Domain.Core.Enums;
using PlaySports.Domain.Validations.UserValidations;

namespace PlaySports.Domain.Commands.UserCommands
{
    public class EditUserCommand : BaseUserCommand
    {
        public EditUserCommand(Guid id, string nome, Sexo sexo, string login, string esporte, string nivel, string localizacao, DateTime dataNascimento, byte[] imagem)
        {
            Id = id;
            Nome = nome;
            Sexo = sexo;
            Login = login;
            Esporte = esporte;
            Nivel = nivel;
            Localizacao = localizacao;
            DataNascimento = dataNascimento;
            Imagem = imagem;
        }

        public override bool IsValid()
        {
            ValidationResult = new EditUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}