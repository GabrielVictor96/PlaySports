using Microsoft.AspNetCore.SignalR;

namespace PlaySports.Hubs
{
    public class TesteHub : Hub
    {
        public void BroadcastMessage(string name, string message)
        {
            Clients.All.SendAsync("broadcastMessage", name, message);
        }

        public void Echo(string name, string message)
        {
            Clients.Client(Context.ConnectionId).SendAsync("echo", name, message + " (echo from server)");
        }

        public void Send(string name, string message)
        {
            Clients.All.SendAsync("broadcastMessage", name, message);
        }
    }
}