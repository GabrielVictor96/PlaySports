using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlaySports.Domain.Commands.UserCommands;
using PlaySports.Domain.Entities;

namespace PlaySports.Domain.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        void Edit(User user);
        void Delete(Guid userId);
        ListUserCommand GetUserById(Guid userId);
        Task<ListUserCommand> GetUserByIdAsync(Guid userId);
        ListUserCommand GetUserByLogin(string login);
        Task<ListUserCommand> GetUserByLoginAsync(string login);
        Task<IEnumerable<ListUserCommand>> GetAllAsync();
        Task<IEnumerable<ListUserCommand>> Match(string cidade, string modalidade);
        ListUserCommand GetUserByNome(string nome);
    }
}