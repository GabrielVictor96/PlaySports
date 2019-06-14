using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore;
using PlaySports.Domain.Commands.UserCommands;
using PlaySports.Domain.Entities;
using PlaySports.Domain.Interfaces;
using PlaySports.Infra.Data.Context;

namespace PlaySports.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public void Add(User user)
        {
            var connection = _db.Database.GetDbConnection();
            connection.Query("SpUser_Add", new
            {
                id = user.Id,
                nome = user.Nome,
                sexo = user.Sexo.ToString(),
                dataNascimento = user.DataNascimento,
                login = user.Login,
                esporte = user.Esporte,
                nivel = user.Nivel,
                localizacao = user.Localizacao,
                senha = user.Senha.SenhaCriptografada,
                imagem = user.Imagem
            }, commandType: CommandType.StoredProcedure);
        }

        public void Edit(User user)
        {
            var connection = _db.Database.GetDbConnection();
            connection.Query("SpUser_Edit", new
            {
                id = user.Id,
                nome = user.Nome,
                sexo = user.Sexo.ToString(),
                dataNascimento = user.DataNascimento,
                login = user.Login,
                esporte = user.Esporte,
                nivel = user.Nivel,
                localizacao = user.Localizacao,
                imagem = user.Imagem
            }, commandType: CommandType.StoredProcedure);
        }

        public void Delete(Guid userId)
        {
            var connection = _db.Database.GetDbConnection();
            connection.Query("SpUser_Delete", new
            {
                id = userId
            }, commandType: CommandType.StoredProcedure);
        }

        public ListUserCommand GetUserById(Guid userId)
        {
            var connection = _db.Database.GetDbConnection();
            return connection.QueryFirstOrDefault<ListUserCommand>("SpUser_GetById", new
            {
                id = userId
            }, commandType: CommandType.StoredProcedure);
        }

        public Task<ListUserCommand> GetUserByIdAsync(Guid userId)
        {
            var connection = _db.Database.GetDbConnection();
            return connection.QueryFirstOrDefaultAsync<ListUserCommand>("SpUser_GetById", new
            {
                id = userId
            }, commandType: CommandType.StoredProcedure);
        }

        public ListUserCommand GetUserByLogin(string login)
        {
            var connection = _db.Database.GetDbConnection();
            return connection.QueryFirstOrDefault<ListUserCommand>("SpUser_GetByLogin", new
            {
                login
            }, commandType: CommandType.StoredProcedure);
        }

        public Task<ListUserCommand> GetUserByLoginAsync(string login)
        {
            var connection = _db.Database.GetDbConnection();
            return connection.QueryFirstOrDefaultAsync<ListUserCommand>("SpUser_GetByLogin", new
            {
                login
            }, commandType: CommandType.StoredProcedure);
        }

        public Task<IEnumerable<ListUserCommand>> GetAllAsync()
        {
            var connection = _db.Database.GetDbConnection();
            return connection.QueryAsync<ListUserCommand>("SpUser_GetAll", commandType: CommandType.StoredProcedure);
        }

        public Task<IEnumerable<ListUserCommand>> Match(string cidade, string modalidade)
        { 
            var connection = _db.Database.GetDbConnection();
            return connection.QueryAsync<ListUserCommand>("SpUser_GetByMatch", new
            {
                esporte = modalidade,
                localizacao = cidade,

            }, commandType: CommandType.StoredProcedure);
        }

        public ListUserCommand GetUserByNome(string nome)
        {
            var connection = _db.Database.GetDbConnection();
            return connection.QueryFirstOrDefault<ListUserCommand>("SpUser_GetByNome", new
            {
                nome
            }, commandType: CommandType.StoredProcedure);
        }

        public void Denuncia(User user)
        {
            var connection = _db.Database.GetDbConnection();
            connection.Query("SpUser_Denuncia", new
            {
                id = user.Id,
                denuncia = user.Denuncia,

            }, commandType: CommandType.StoredProcedure);
        }
    }
}