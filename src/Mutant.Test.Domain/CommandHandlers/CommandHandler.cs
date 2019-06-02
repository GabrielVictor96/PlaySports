using System.Threading.Tasks;
using MediatR;
using PlaySports.Domain.Core.Bus;
using PlaySports.Domain.Core.Commands;
using PlaySports.Domain.Core.Notifications;

namespace PlaySports.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        protected CommandHandler(IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _bus = bus;
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        protected Task ReturnNotification(string messageType, string message)
        {
            _bus.RaiseEvent(new DomainNotification(messageType, message));
            return Task.CompletedTask;
        }

        protected bool Commit()
        {
            return !_notifications.HasNotifications();
        }
    }
}