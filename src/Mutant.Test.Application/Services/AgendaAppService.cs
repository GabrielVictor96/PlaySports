using AutoMapper;
using PlaySports.Application.Interfaces;
using PlaySports.Application.ViewModels;
using PlaySports.Domain.Commands.AgendaCommands;
using PlaySports.Domain.Core.Bus;
using PlaySports.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlaySports.Application.Services
{
    public class AgendaAppService : IAgendaAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly IAgendaRepository _agendaRepository;

        public AgendaAppService(IMapper mapper, IMediatorHandler bus, IAgendaRepository agendaRepository)
        {
            _mapper = mapper;
            _bus = bus;
            _agendaRepository = agendaRepository;
        }

        public void Add(AgendaViewModel agendaViewModel)
        {
            var agendaAddCommand = _mapper.Map<AddAgendaCommand>(agendaViewModel);
            _bus.SendCommand(agendaAddCommand);
        }

        public Task<IEnumerable<AgendaViewModel>> Atividades(string usuario)
        {
            return _mapper.Map<Task<IEnumerable<AgendaViewModel>>>(_agendaRepository.Atividades(usuario));
        }

        public Task<AgendaViewModel> GetAtividadeByIdAsync(Guid atividadeId)
        {
            return _mapper.Map<Task<AgendaViewModel>>(_agendaRepository.GetAtividadeByIdAsync(atividadeId));
        }

        public object Edit(Guid atividadeId, string inativar)
        {
            return _mapper.Map<Task<AgendaViewModel>>(_agendaRepository.Edit(atividadeId,inativar));
        }
    }
}
