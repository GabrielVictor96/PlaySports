using FluentValidation;
using PlaySports.Domain.Commands.NotaCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Domain.Validations.Nota
{
    public class BaseNotaCommandValidation<T> : AbstractValidator<T> where T : BaseNotaCommand
    {
        private string MaximumLengthMessage(int value) => $"Quantidade de caracteres permitida ultrapassado. Limite permitido: {value}";

        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("O id é de preenchimento obrigatório.");
        }

        protected void ValidateAgendaId()
        {
            RuleFor(x => x.AgendaId)
                .NotNull()
                .NotEmpty().WithMessage("O criador é de preenchimento obrigatório.")
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateCriador()
        {
            RuleFor(x => x.Criador)
                .NotNull()
                .NotEmpty().WithMessage("O criador é de preenchimento obrigatório.")
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateNotaMembro1()
        {
            RuleFor(x => x.NotaMembro1)
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateNotaMembro2()
        {
            RuleFor(x => x.NotaMembro2)
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateNotaMembro3()
        {
            RuleFor(x => x.NotaMembro3)
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateNotaMembro4()
        {
            RuleFor(x => x.NotaMembro4)
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateNotaMembro5()
        {
            RuleFor(x => x.NotaMembro5)
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateNotaMembro6()
        {
            RuleFor(x => x.NotaMembro6)
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateNotaMembro7()
        {
            RuleFor(x => x.NotaMembro7)
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateNotaMembro8()
        {
            RuleFor(x => x.NotaMembro8)
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateNotaMembro9()
        {
            RuleFor(x => x.NotaMembro9)
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }
    }
}
