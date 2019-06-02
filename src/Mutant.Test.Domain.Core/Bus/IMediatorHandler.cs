using System.Threading.Tasks;
using PlaySports.Domain.Core.Commands;
using PlaySports.Domain.Core.Events;

namespace PlaySports.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T theCommand) where T : Command;
        Task RaiseEvent<T>(T theEvent) where T : Event;
    }
}