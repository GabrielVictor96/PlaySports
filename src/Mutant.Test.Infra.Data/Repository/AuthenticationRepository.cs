using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore;
using PlaySports.Domain.Commands.AuthenticationCommands;
using PlaySports.Domain.Commands.UserCommands;
using PlaySports.Domain.Interfaces;
using PlaySports.Infra.Data.Context;

namespace PlaySports.Infra.Data.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ApplicationDbContext _db;

        public AuthenticationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<(bool, ListUserCommand)> ValidateLogin(LoginCommand login)
        {
            var connection = _db.Database.GetDbConnection();
            var user = connection.QueryFirstOrDefaultAsync<ListUserCommand>("SpAuthentication_Login", new
            {
                login = login.Login,
                senha = login.Senha.SenhaCriptografada
            }, commandTimeout: 240, commandType: CommandType.StoredProcedure);

            var isAuthorized = user.Result != null; 
            var result = (isAuthorized, isAuthorized ? user.Result : null);

            return Task.FromResult(result);
        }
    }
}