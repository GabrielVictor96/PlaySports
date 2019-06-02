using System.Threading.Tasks;
using PlaySports.Application.ViewModels;

namespace PlaySports.Application.Interfaces
{
    public interface IAuthenticationAppService
    {
        Task<(bool, UserViewModel)> ValidateLogin(LoginViewModel loginViewModel);
    }
}