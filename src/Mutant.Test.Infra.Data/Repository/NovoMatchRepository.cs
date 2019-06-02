using Dapper;
using Microsoft.EntityFrameworkCore;
using PlaySports.Domain.Commands.NovoMatchCommands;
using PlaySports.Domain.Entities;
using PlaySports.Domain.Interfaces;
using PlaySports.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace PlaySports.Infra.Data.Repository
{
    public class NovoMatchRepository : INovoMatchRepository
    {
        private readonly ApplicationDbContext _db;

        public NovoMatchRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public void AddNovoMatch(NovoMatch novoMatch)
        {
            var connection = _db.Database.GetDbConnection();
            connection.Query("SpNovoMatch_AddNovoMatch", new
            {
                id = novoMatch.Id,
                usuarioPrimario = novoMatch.UsuarioPrimario,
                usuarioSecundario = novoMatch.UsuarioSecundario

            }, commandType: CommandType.StoredProcedure);
        }

        public Task<IEnumerable<ListNovoMatchCommand>> ProcurarUsuarioPrimario(string UsuarioPrimario)
        {
            var connection = _db.Database.GetDbConnection();
            return connection.QueryAsync<ListNovoMatchCommand>("SpNovoMatch_ProcurarUsuarioPrimario", new
            {
                usuarioPrimario = UsuarioPrimario,

            }, commandType: CommandType.StoredProcedure);
        }

        public Task<IEnumerable<ListNovoMatchCommand>> ProcurarUsuarioSecundario(string UsuarioSecundario)
        {
            var connection = _db.Database.GetDbConnection();
            return connection.QueryAsync<ListNovoMatchCommand>("SpNovoMatch_ProcurarUsuarioSecundario", new
            {
                usuarioSecundario = UsuarioSecundario,

            }, commandType: CommandType.StoredProcedure);
        }

    }
}
