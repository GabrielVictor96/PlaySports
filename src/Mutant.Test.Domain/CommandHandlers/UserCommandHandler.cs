using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PlaySports.Domain.Commands.UserCommands;
using PlaySports.Domain.Core.Bus;
using PlaySports.Domain.Core.Notifications;
using PlaySports.Domain.Entities;
using PlaySports.Domain.Interfaces;

namespace PlaySports.Domain.CommandHandlers
{
    public class UserCommandHandler : CommandHandler,
        IRequestHandler<AddUserCommand>,
        IRequestHandler<EditUserCommand>,
        IRequestHandler<DeleteUserCommand>
    {
        private readonly IMediatorHandler _bus;
        private readonly IUserRepository _userRepository;

        public UserCommandHandler(IMediatorHandler bus, INotificationHandler<DomainNotification> notifications, IUserRepository userRepository) 
            : base(bus, notifications)
        {
            _bus = bus;
            _userRepository = userRepository;
        }

        public Task<Unit> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Unit.Task;
            }

            if (_userRepository.GetUserByLogin(command.Login) != null)
            {
                ReturnNotification(command.MessageType, "O login digitado já está em uso.");
                return Unit.Task;
            }

            var user = new User(command.Nome, command.Sexo, command.Login, command.Esporte, command.Nivel, command.Localizacao, command.DataNascimento, command.Imagem);
            user.FillPassword(command.Senha);

            _userRepository.Add(user);

            if (Commit())
            {
                // raise event
            }

            return Unit.Task;
        }

        public Task<Unit> Handle(EditUserCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Unit.Task;
            }

            var user = new User(command.Nome, command.Sexo, command.Login, command.Esporte, command.Nivel, command.Localizacao, command.DataNascimento, command.Imagem);
            user.FillId(command.Id);

            var existingUser = _userRepository.GetUserByLogin(command.Login);
            if (existingUser != null && existingUser.Id != command.Id)
            {
                ReturnNotification(command.MessageType, "O login digitado já está em uso.");
                return Unit.Task;
            }
            
            _userRepository.Edit(user);
            if (Commit())
            {
                // raise event
            }

            return Unit.Task;
        }

        public Task<Unit> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Unit.Task;
            }

            _userRepository.Delete(command.Id);
            if (Commit())
            {
                // raise event
            }

            return Unit.Task;
        }
    }
}