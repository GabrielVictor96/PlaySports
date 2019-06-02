using MediatR;
using PlaySports.Domain.Commands.NotaCommands;
using PlaySports.Domain.Core.Bus;
using PlaySports.Domain.Core.Notifications;
using PlaySports.Domain.Entities;
using PlaySports.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlaySports.Domain.CommandHandlers
{
    public class NotaCommandHandler : CommandHandler,
        IRequestHandler<AddNotaCommand>
    {
        private readonly IMediatorHandler _bus;
        private readonly INotaRepository _notaRepository;

        public NotaCommandHandler(IMediatorHandler bus, INotificationHandler<DomainNotification> notifications, INotaRepository notaRepository)
          : base(bus, notifications)
        {
            _bus = bus;
            _notaRepository = notaRepository;
        }

        public Task<Unit> Handle(AddNotaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Unit.Task;
            }


            var nota = new Nota(command.AgendaId, command.Criador, command.NotaMembro1, command.NotaMembro2, command.NotaMembro3, command.NotaMembro4, command.NotaMembro5, command.NotaMembro6, command.NotaMembro7, command.NotaMembro8, command.NotaMembro9);

            _notaRepository.Add(nota);

            if (Commit())
            {
                // raise event
            }

            return Unit.Task;
        }
    }
}
