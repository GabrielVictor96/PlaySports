using FluentValidation;
using PlaySports.Domain.Commands.AgendaCommands;

namespace PlaySports.Domain.Validations.Agenda
{
    public class BaseAgendaCommandValidation<T> : AbstractValidator<T> where T : BaseAgendaCommand
    {
        private string MaximumLengthMessage(int value) => $"Quantidade de caracteres permitida ultrapassado. Limite permitido: {value}";

        protected void ValidateId()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("O id é de preenchimento obrigatório.");
        }

        protected void ValidateCriador()
        {
            RuleFor(x => x.Criador)
                .NotNull()
                .NotEmpty().WithMessage("O criador é de preenchimento obrigatório.")
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateMembro1()
        {
            RuleFor(x => x.Membro1)
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateMembro2()
        {
            RuleFor(x => x.Membro2)
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateMembro3()
        {
            RuleFor(x => x.Membro3)
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateMembro4()
        {
            RuleFor(x => x.Membro4)
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateMembro5()
        {
            RuleFor(x => x.Membro5)
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateMembro6()
        {
            RuleFor(x => x.Membro6)
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateMembro7()
        {
            RuleFor(x => x.Membro7)
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateMembro8()
        {
            RuleFor(x => x.Membro8)
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateMembro9()
        {
            RuleFor(x => x.Membro9)
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateAtividade()
        {
            RuleFor(x => x.Atividade)
                .NotNull()
                .NotEmpty().WithMessage("A atividade é de preenchimento obrigatório.")
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateLocal()
        {
            RuleFor(x => x.Local)
                .NotNull()
                .NotEmpty().WithMessage("O local é de preenchimento obrigatório.")
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }

        protected void ValidateData()
        {
            RuleFor(x => x.Data)
                .NotNull()
                .NotEmpty().WithMessage("A data é de preenchimento obrigatório.");
        }

        protected void ValidateAtivo()
        {
            RuleFor(x => x.Ativo)
                .MaximumLength(100).WithMessage(MaximumLengthMessage(100));
        }
    }
}
