using AutoMapper;
using PlaySports.Application.Interfaces;
using PlaySports.Application.ViewModels;
using PlaySports.Domain.Commands.NotaCommands;
using PlaySports.Domain.Core.Bus;
using PlaySports.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaySports.Application.Services
{
    public class NotaAppService : INotaAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly INotaRepository _notaRepository;

        public NotaAppService(IMapper mapper, IMediatorHandler bus, INotaRepository notaRepository)
        {
            _mapper = mapper;
            _bus = bus;
            _notaRepository = notaRepository;
        }

        public void Add(NotaViewModel notaViewModel)
        {
            var notaAddCommand = _mapper.Map<AddNotaCommand>(notaViewModel);
            _bus.SendCommand(notaAddCommand);
        }

        public Task<NotaViewModel> GetAtividadeByIdAsync(string atividadeId)
        {
            return _mapper.Map<Task<NotaViewModel>>(_notaRepository.GetAtividadeByIdAsync(atividadeId));
        }

    }
}
