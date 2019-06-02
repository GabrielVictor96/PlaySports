using AutoMapper;
using PlaySports.Application.Interfaces;
using PlaySports.Application.ViewModels;
using PlaySports.Domain.Commands.NovoMatchCommands;
using PlaySports.Domain.Core.Bus;
using PlaySports.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaySports.Application.Services
{
    public class NovoMatchAppService : INovoMatchAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly INovoMatchRepository _novoMatchRepository;

        public NovoMatchAppService(IMapper mapper, IMediatorHandler bus, INovoMatchRepository novoMatchRepository)
        {
            _mapper = mapper;
            _bus = bus;
            _novoMatchRepository = novoMatchRepository;
        }

        public void AddNovoMatch(NovoMatchViewModel novoMatchViewModel)
        {
            var novoMatchAddCommand = _mapper.Map<AddNovoMatchCommand>(novoMatchViewModel);
            _bus.SendCommand(novoMatchAddCommand);
        }

        public Task<IEnumerable<NovoMatchViewModel>> ProcurarUsuarioPrimario(string UsuarioPrimario)
        {
            return _mapper.Map<Task<IEnumerable<NovoMatchViewModel>>>(_novoMatchRepository.ProcurarUsuarioPrimario(UsuarioPrimario));
        }

        public Task<IEnumerable<NovoMatchViewModel>> ProcurarUsuarioSecundario(string UsuarioSecundario)
        {
            return _mapper.Map<Task<IEnumerable<NovoMatchViewModel>>>(_novoMatchRepository.ProcurarUsuarioSecundario(UsuarioSecundario));
        }
    }
}
