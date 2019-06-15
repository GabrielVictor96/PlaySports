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
    [Route("eventos")]
    public class EventosController : BaseController
    {
        private readonly IAgendaAppService _agendaAppService;
        private readonly INotaAppService _notaAppService;

        public EventosController(INotificationHandler<DomainNotification> notifications, IAgendaAppService agendaAppService, INotaAppService notaAppService)
            : base(notifications)
        {
            _agendaAppService = agendaAppService;
            _notaAppService = notaAppService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var users = await _agendaAppService.ProcurarMembro(User.Identity.Name);



            return View(new PagedList<AgendaViewModel>(users, 1, 10));
        }


        [HttpGet]
        [Route("{id}/details")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var agendaViewModel = await _agendaAppService.GetAtividadeByIdAsync(id.Value);
            if (agendaViewModel == null)
            {
                return NotFound();
            }

            if (agendaViewModel.Membro1 == null)
                agendaViewModel.Membro1 = "Sem Cadastro";

            if (agendaViewModel.Membro2 == null)
                agendaViewModel.Membro2 = "Sem Cadastro";

            if (agendaViewModel.Membro3 == null)
                agendaViewModel.Membro3 = "Sem Cadastro";

            if (agendaViewModel.Membro4 == null)
                agendaViewModel.Membro4 = "Sem Cadastro";

            if (agendaViewModel.Membro5 == null)
                agendaViewModel.Membro5 = "Sem Cadastro";

            if (agendaViewModel.Membro6 == null)
                agendaViewModel.Membro6 = "Sem Cadastro";

            if (agendaViewModel.Membro7 == null)
                agendaViewModel.Membro7 = "Sem Cadastro";

            if (agendaViewModel.Membro8 == null)
                agendaViewModel.Membro8 = "Sem Cadastro";

            if (agendaViewModel.Membro9 == null)
                agendaViewModel.Membro9 = "Sem Cadastro";


            return View(agendaViewModel);
        }

        [HttpGet]
        [Route("{id}/avaliacao")]
        public async Task<IActionResult> Avaliacao(string id)
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

            ViewBag.Usuario = User.Identity.Name;

            return View(users);
        }
    }
}