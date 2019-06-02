using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlaySports.Domain.Core.Notifications;
using PlaySports.UI.MvcCore.Enums;

namespace PlaySports.UI.MvcCore.Controllers
{
    public class BaseController : Controller
    {
        private readonly DomainNotificationHandler _notifications;

        public BaseController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        public bool OpIsValid()
        {
            return !_notifications.HasNotifications();
        }

        public void AlertToast(string title, NotificationType notificationType)
        {
            var alertMessage = "swal({" +
                               $"title: '{title}', " +
                               $"type: '{notificationType.ToString().ToLowerInvariant()}', " +
                               "position: 'bottom-end', " +
                               "timer: 3000, " +
                               "toast: true, " +
                               "showConfirmButton: false, " +
                               "confirmButtonClass: 'rounded-0'})";

            TempData["Notification"] = alertMessage;
        }

        public void AlertToast(string title, string text, NotificationType notificationType)
        {
            var alertMessage = "swal({" +
                               $"title: '{title}', " +
                               $"type: '{notificationType.ToString().ToLowerInvariant()}', " +
                               $"text: '{text}', " +
                               "position: 'bottom-end', " +
                               "timer: 3000, " +
                               "toast: true, " +
                               "showConfirmButton: false, " +
                               "confirmButtonClass: 'rounded-0'})";

            TempData["Notification"] = alertMessage;
        }
    }
}