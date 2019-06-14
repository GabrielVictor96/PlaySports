using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PlaySports.Application.Interfaces;
using PlaySports.Application.ViewModels;
using PlaySports.Domain.Commands.UserCommands;
using PlaySports.Domain.Core.Bus;
using PlaySports.Domain.Interfaces;

namespace PlaySports.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly IUserRepository _userRepository;

        public UserAppService(IMapper mapper, IMediatorHandler bus, IUserRepository userRepository)
        {
            _mapper = mapper;
            _bus = bus;
            _userRepository = userRepository;
        }

        public void Add(RegisterUserViewModel registerUserViewModel)
        {
            var userAddCommand = _mapper.Map<AddUserCommand>(registerUserViewModel);
            _bus.SendCommand(userAddCommand);
        }

        public void Edit(UserViewModel userViewModel)
        {
            var userEditCommand = _mapper.Map<EditUserCommand>(userViewModel);
            _bus.SendCommand(userEditCommand);
        }

        public void Delete(Guid userId)
        {
            var userDeleteCommand = new DeleteUserCommand(userId);
            _bus.SendCommand(userDeleteCommand);
        }

        public UserViewModel GetUserById(Guid userId)
        {
            return _mapper.Map<UserViewModel>(_userRepository.GetUserById(userId));
        }

        public Task<UserViewModel> GetUserByIdAsync(Guid userId)
        {
            return _mapper.Map<Task<UserViewModel>>(_userRepository.GetUserByIdAsync(userId));
        }

        public UserViewModel GetUserByLogin(string login)
        {
            return _mapper.Map<UserViewModel>(_userRepository.GetUserByLogin(login));
        }

        public Task<UserViewModel> GetUserByLoginAsync(string login)
        {
            return _mapper.Map<Task<UserViewModel>>(_userRepository.GetUserByLogin(login));
        }

        public Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            return _mapper.Map<Task<IEnumerable<UserViewModel>>>(_userRepository.GetAllAsync());
        }

        public Task<IEnumerable<UserViewModel>> Match(string cidade, string modalidade)
        {
            return _mapper.Map<Task<IEnumerable<UserViewModel>>>(_userRepository.Match(cidade, modalidade));
        }

        public UserViewModel GetUserByNome(string nome)
        {
            return _mapper.Map<UserViewModel>(_userRepository.GetUserByNome(nome));
        }


        public void Denuncia(UserViewModel userViewModel)
        {
            var userEditCommand = _mapper.Map<EditUserCommand>(userViewModel);
            _bus.SendCommand(userEditCommand);
        }
    }
}