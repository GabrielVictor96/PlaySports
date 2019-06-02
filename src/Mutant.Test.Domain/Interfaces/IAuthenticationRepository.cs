using System.Threading.Tasks;
using PlaySports.Domain.Commands.AuthenticationCommands;
using PlaySports.Domain.Commands.UserCommands;

namespace PlaySports.Domain.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<(bool, ListUserCommand)> ValidateLogin(LoginCommand login);
    }
}