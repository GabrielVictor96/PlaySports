using MediatR;
using PlaySports.Domain.Commands.NovoMatchCommands;
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
    public class NovoMatchCommandHandler : CommandHandler,
        IRequestHandler<AddNovoMatchCommand>
    {

        private readonly IMediatorHandler _bus;
        private readonly INovoMatchRepository _novoMatchRepository;

        public NovoMatchCommandHandler(IMediatorHandler bus, INotificationHandler<DomainNotification> notifications, INovoMatchRepository novoMatchRepository)
           : base(bus, notifications)
        {
            _bus = bus;
            _novoMatchRepository = novoMatchRepository;
        }


        public Task<Unit> Handle(AddNovoMatchCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Unit.Task;
            }


            var user = new NovoMatch(command.UsuarioPrimario, command.UsuarioSecundario);

            _novoMatchRepository.AddNovoMatch(user);

            if (Commit())
            {
                // raise event
            }

            return Unit.Task;
        }

    }
}
