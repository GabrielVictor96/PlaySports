using FluentValidation;
using PlaySports.Domain.Commands.NovoMatchCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Domain.Validations.NovoMatchValidations
{
    public class BaseNovoMatchCommandValidation<T> : AbstractValidator<T> where T : BaseNovoMatchCommand
    {
        private string MaximumLengthMessage(int value) => $"Quantidade de caracteres permitida ultrapassado. Limite permitido: {value}";


        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("O id é de preenchimento obrigatório.");
        }

        protected void ValidateUsuarioPrimario()
        {
            RuleFor(x => x.UsuarioPrimario)
                .NotNull()
                .NotEmpty().WithMessage("O nome é de preenchimento obrigatório.")
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateUsuarioSecundario()
        {
            RuleFor(x => x.UsuarioSecundario)
                .NotNull()
                .NotEmpty().WithMessage("O nome é de preenchimento obrigatório.")
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }





    }
}
