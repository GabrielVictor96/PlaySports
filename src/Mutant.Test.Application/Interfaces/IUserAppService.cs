using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlaySports.Application.ViewModels;

namespace PlaySports.Application.Interfaces
{
    public interface IUserAppService
    {
        void Add(RegisterUserViewModel registerUserViewModel);
        void Edit(UserViewModel userViewModel);
        void Delete(Guid userId);
        UserViewModel GetUserById(Guid userId);
        Task<UserViewModel> GetUserByIdAsync(Guid userId);
        UserViewModel GetUserByLogin(string login);
        Task<UserViewModel> GetUserByLoginAsync(string login);
        Task<IEnumerable<UserViewModel>> GetAllAsync();
        Task<IEnumerable<UserViewModel>> Match(string cidade, string modalidade);
        UserViewModel GetUserByNome(string nome);
    }
}