using System.Threading.Tasks;
using AutoMapper;
using PlaySports.Application.Interfaces;
using PlaySports.Application.ViewModels;
using PlaySports.Domain.Commands.AuthenticationCommands;
using PlaySports.Domain.Core.Bus;
using PlaySports.Domain.Interfaces;

namespace PlaySports.Application.Services
{
    public class AuthenticationAppService : IAuthenticationAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationAppService(IMapper mapper, IMediatorHandler bus, IAuthenticationRepository authenticationRepository)
        {
            _mapper = mapper;
            _bus = bus;
            _authenticationRepository = authenticationRepository;
        }

        public Task<(bool, UserViewModel)> ValidateLogin(LoginViewModel loginViewModel)
        {
            var loginCommand = _mapper.Map<LoginCommand>(loginViewModel);
            return _mapper.Map<Task<(bool, UserViewModel)>>(_authenticationRepository.ValidateLogin(loginCommand));
        }
    }
}