using Dapper;
using Microsoft.EntityFrameworkCore;
using PlaySports.Domain.Commands.MatchCommands;
using PlaySports.Domain.Entities;
using PlaySports.Domain.Interfaces;
using PlaySports.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PlaySports.Infra.Data.Repository
{
    public class MatchRepository : IMatchRepository
    {
        private readonly ApplicationDbContext _db;

        public MatchRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddMatch(Match match)
        {
            var connection = _db.Database.GetDbConnection();
            connection.Query("SpMatch_AddMatch", new
            {
                id = match.Id,
                usuarioCurtiu = match.UsuarioCurtiu,
                usuarioCurtido = match.UsuarioCurtido

            }, commandType: CommandType.StoredProcedure);
        }

        public ListMatchCommand ProcurarMatch(string UsuarioCurtiu, string UsuarioCurtido)
        {
            var connection = _db.Database.GetDbConnection();
            return connection.QueryFirstOrDefault<ListMatchCommand>("SpMatch_ProcurarMatch", new
            {
                usuarioCurtiu = UsuarioCurtiu,
                usuarioCurtido = UsuarioCurtido

            }, commandType: CommandType.StoredProcedure);
        }

    }
}
