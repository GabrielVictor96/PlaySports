using Dapper;
using Microsoft.EntityFrameworkCore;
using PlaySports.Domain.Commands.NotaCommands;
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
    public class NotaRepository : INotaRepository
    {
        private readonly ApplicationDbContext _db;

        public NotaRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(Nota nota)
        {
            var connection = _db.Database.GetDbConnection();
            connection.Query("SpNota_AddNota", new
            {
                id = nota.Id,
                agendaId = nota.AgendaId,
                criador = nota.Criador,
                notaMembro1 = nota.NotaMembro1,
                notaMembro2 = nota.NotaMembro2,
                notaMembro3 = nota.NotaMembro3,
                notaMembro4 = nota.NotaMembro4,
                notaMembro5 = nota.NotaMembro5,
                notaMembro6 = nota.NotaMembro6,
                notaMembro7 = nota.NotaMembro7,
                notaMembro8 = nota.NotaMembro8,
                notaMembro9 = nota.NotaMembro9,

            }, commandType: CommandType.StoredProcedure);
        }

        public Task<ListNotaCommand> GetAtividadeByIdAsync(string atividadeId)
        {
            var connection = _db.Database.GetDbConnection();
            return connection.QueryFirstOrDefaultAsync<ListNotaCommand>("SpNota_Detalhes", new
            {
                agendaId = atividadeId
            }, commandType: CommandType.StoredProcedure);
        }
    }
}
