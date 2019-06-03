using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlaySports.Application.Interfaces;
using PlaySports.Application.ViewModels;
using PlaySports.Domain.Core.Notifications;
using PlaySports.UI.MvcCore.Controllers;
using X.PagedList;

namespace PlaySports.Controllers
{
    [Authorize]
    [Route("nota")]
    public class NotaController : BaseController
    {
        private readonly IAgendaAppService _agendaAppService;
        private readonly INotaAppService _notaAppService;
        private static string usuario;


        public NotaController(INotificationHandler<DomainNotification> notifications, IAgendaAppService agendaAppService,  INotaAppService notaAppService)
            : base(notifications)
        {
            _agendaAppService = agendaAppService;
            _notaAppService = notaAppService;
        }



        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Index(string id)
        {

            var users = await _agendaAppService.ProcurarMembro(id);
            usuario = id;


            return View(new PagedList<AgendaViewModel>(users, 1, 10));
        }


        [HttpGet]
        [Route("{id}/details")]
        public async Task<IActionResult> Details(string id)
        {
            var agendaViewModel = await _agendaAppService.GetAtividadeByIdAsync(new Guid(id));

            var users = await _notaAppService.GetAtividadeByIdAsync(id);

            ViewBag.Membro1 = agendaViewModel.Membro1;
            ViewBag.Membro2 = agendaViewModel.Membro2;
            ViewBag.Membro3 = agendaViewModel.Membro3;
            ViewBag.Membro4 = agendaViewModel.Membro4;
            ViewBag.Membro5 = agendaViewModel.Membro5;
            ViewBag.Membro6 = agendaViewModel.Membro6;
            ViewBag.Membro7 = agendaViewModel.Membro7;
            ViewBag.Membro8 = agendaViewModel.Membro8;
            ViewBag.Membro9 = agendaViewModel.Membro9;
            ViewBag.Atividade = agendaViewModel.Atividade;
            ViewBag.Local = agendaViewModel.Local;
            ViewBag.Data = agendaViewModel.Data;

            ViewBag.Usuario = usuario;

            return View(users);
        }
    }
}