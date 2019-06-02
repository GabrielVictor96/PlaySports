using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PlaySports.Application.Interfaces;
using PlaySports.Application.ViewModels;
using PlaySports.Domain.Commands.MatchCommands;
using PlaySports.Domain.Core.Bus;
using PlaySports.Domain.Interfaces;

namespace PlaySports.Application.Services
{
    public class MatchAppService : IMatchAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly IMatchRepository _matchRepository;


        public MatchAppService(IMapper mapper, IMediatorHandler bus, IMatchRepository matchRepository)
        {
            _mapper = mapper;
            _bus = bus;
            _matchRepository = matchRepository;
        }

        public void AddMatch(MatchViewModel matchViewModel)
        {
            var matchAddCommand = _mapper.Map<AddMatchCommand>(matchViewModel);
            _bus.SendCommand(matchAddCommand);
        }

        public MatchViewModel ProcurarMatch(string usuarioCurtiu, string usuarioCurtido)
        {
            return _mapper.Map<MatchViewModel>(_matchRepository.ProcurarMatch(usuarioCurtiu, usuarioCurtido));
        }

    }
}
