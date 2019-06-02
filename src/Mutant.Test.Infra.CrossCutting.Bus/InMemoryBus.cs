using System.Threading.Tasks;
using MediatR;
using PlaySports.Domain.Core.Bus;
using PlaySports.Domain.Core.Commands;
using PlaySports.Domain.Core.Events;

namespace PlaySports.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<T>(T theCommand) where T : Command
        {
            return _mediator.Send(theCommand);
        }

        public Task RaiseEvent<T>(T theEvent) where T : Event
        {
            return _mediator.Publish(theEvent);
        }
    }
}