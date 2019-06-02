using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PlaySports.Domain.Commands.AuthenticationCommands;
using PlaySports.Domain.Core.Bus;
using PlaySports.Domain.Core.Notifications;
using PlaySports.Domain.Interfaces;

namespace PlaySports.Domain.CommandHandlers
{
    public class AuthenticationCommandHandler : CommandHandler,
        IRequestHandler<LoginCommand>
    {
        private readonly IMediatorHandler _bus;
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationCommandHandler(IMediatorHandler bus, INotificationHandler<DomainNotification> notifications, IAuthenticationRepository authenticationRepository)
            : base(bus, notifications)
        {
            _bus = bus;
            _authenticationRepository = authenticationRepository;
        }

        public Task<Unit> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}