using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlaySports.Domain.Core.Notifications;

namespace PlaySports.UI.MvcCore.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly DomainNotificationHandler _notifications;

        public SummaryViewComponent(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notifications = await Task.FromResult(_notifications.GetNotifications());
            notifications.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Value));

            TempData["ErrorNotificationCount"] = notifications.Count;
            return View();
        }
    }
}