using MediatR;
using PlaySports.Domain.Commands.MatchCommands;
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
    public class MatchCommandHandler : CommandHandler,
        IRequestHandler<AddMatchCommand>
    {
        private readonly IMediatorHandler _bus;
        private readonly IMatchRepository _matchRepository;

        public MatchCommandHandler(IMediatorHandler bus, INotificationHandler<DomainNotification> notifications, IMatchRepository matchRepository)
           : base(bus, notifications)
        {
            _bus = bus;
            _matchRepository = matchRepository;
        }


        public Task<Unit> Handle(AddMatchCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Unit.Task;
            }


            var user = new Match(command.UsuarioCurtiu, command.UsuarioCurtido);

            _matchRepository.AddMatch(user);

            if (Commit())
            {
                // raise event
            }

            return Unit.Task;
        }
       
    }
}
