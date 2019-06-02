using MediatR;
using PlaySports.Domain.Commands.AgendaCommands;
using PlaySports.Domain.Core.Bus;
using PlaySports.Domain.Core.Notifications;
using PlaySports.Domain.Entities;
using PlaySports.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PlaySports.Domain.CommandHandlers
{
    public class AgendaCommandHandler : CommandHandler,
        IRequestHandler<AddAgendaCommand>
    {
        private readonly IMediatorHandler _bus;
        private readonly IAgendaRepository _agendaRepository;

        public AgendaCommandHandler(IMediatorHandler bus, INotificationHandler<DomainNotification> notifications, IAgendaRepository agendaRepository)
          : base(bus, notifications)
        {
            _bus = bus;
            _agendaRepository = agendaRepository;
        }

        public Task<Unit> Handle(AddAgendaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Unit.Task;
            }


            var agenda = new Agenda(command.Criador, command.Membro1, command.Membro2, command.Membro3, command.Membro4, command.Membro5, command.Membro6, command.Membro7, command.Membro8, command.Membro9, command.Atividade, command.Local, command.Data, command.Ativo);

            _agendaRepository.Add(agenda);

            if (Commit())
            {
                // raise event
            }

            return Unit.Task;
        }
    }
}
