using Dapper;
using Microsoft.EntityFrameworkCore;
using PlaySports.Domain.Commands.AgendaCommands;
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
    public class AgendaRepository : IAgendaRepository
    {
        private readonly ApplicationDbContext _db;

        public AgendaRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(Agenda agenda)
        {
            var connection = _db.Database.GetDbConnection();
            connection.Query("SpAgenda_AddAgenda", new
            {
                id = agenda.Id,
                criador = agenda.Criador,
                membro1 = agenda.Membro1,
                membro2 = agenda.Membro2,
                membro3 = agenda.Membro3,
                membro4 = agenda.Membro4,
                membro5 = agenda.Membro5,
                membro6 = agenda.Membro6,
                membro7 = agenda.Membro7,
                membro8 = agenda.Membro8,
                membro9 = agenda.Membro9,
                atividade = agenda.Atividade,
                local = agenda.Local,
                data = agenda.Data,
                ativo = agenda.Ativo,
            }, commandType: CommandType.StoredProcedure);
        }

        public Task<IEnumerable<ListAgendaCommand>> Atividades(string usuario)
        {
            var connection = _db.Database.GetDbConnection();
            return connection.QueryAsync<ListAgendaCommand>("SpAgenda_Procurar", new
            {
                criador = usuario
            }, commandType: CommandType.StoredProcedure);
        }

        public Task<ListAgendaCommand> GetAtividadeByIdAsync(Guid atividadeId)
        {
            var connection = _db.Database.GetDbConnection();
            return connection.QueryFirstOrDefaultAsync<ListAgendaCommand>("SpAgenda_Detalhes", new
            {
                id = atividadeId
            }, commandType: CommandType.StoredProcedure);
        }
    }
}
