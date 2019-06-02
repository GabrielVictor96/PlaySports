﻿using FluentValidation;
using PlaySports.Domain.Commands.MatchCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Domain.Validations.MatchValidations
{
    public class BaseMatchCommandValidation<T> : AbstractValidator<T> where T : BaseMatchCommand
    {
        private string MaximumLengthMessage(int value) => $"Quantidade de caracteres permitida ultrapassado. Limite permitido: {value}";

        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("O id é de preenchimento obrigatório.");
        }

        protected void ValidateUsuarioCurtiu()
        {
            RuleFor(x => x.UsuarioCurtiu)
                .NotNull()
                .NotEmpty().WithMessage("O nome é de preenchimento obrigatório.")
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateUsuarioCurtido()
        {
            RuleFor(x => x.UsuarioCurtido)
                .NotNull()
                .NotEmpty().WithMessage("O nome é de preenchimento obrigatório.")
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }
    }
}
