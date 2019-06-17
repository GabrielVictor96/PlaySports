using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlaySports.Application.Interfaces;
using PlaySports.Application.ViewModels;
using PlaySports.Domain.Core.Notifications;
using PlaySports.UI.MvcCore.Controllers;
using PlaySports.UI.MvcCore.Enums;
using X.PagedList;

namespace PlaySports.Controllers
{

    [Authorize]
    [Route("agenda")]
    public class AgendaController : BaseController
    {
        private readonly IAgendaAppService _agendaAppService;
        private readonly INovoMatchAppService _novoMatchAppService;
        private readonly IUserAppService _userAppService;
        private readonly INotaAppService _notaAppService;

        private static string criador;

        public AgendaController(INotificationHandler<DomainNotification> notifications, IAgendaAppService agendaAppService, INovoMatchAppService novoMatchAppService, IUserAppService userAppService, INotaAppService notaAppService)
            : base(notifications)
        {
            _agendaAppService = agendaAppService;
            _novoMatchAppService = novoMatchAppService;
            _userAppService = userAppService;
            _notaAppService = notaAppService;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index(int pagina = 1)
        {
            var users = await _agendaAppService.Atividades(User.Identity.Name);
            
            
            return View(new PagedList<AgendaViewModel>(users, pagina, 10));
        }
        

        [HttpGet]
        [AllowAnonymous]
        [Route("registrar")]
        public async Task<IActionResult> Create()
        {
            string nome = User.Identity.Name;
            IList<UserViewModel> match = new List<UserViewModel>();

            var listaPrimario = await _novoMatchAppService.ProcurarUsuarioPrimario(nome);
            if (listaPrimario != null)
            {
                foreach (var item in listaPrimario)
                {
                    var userSecundario = _userAppService.GetUserByNome(item.UsuarioSecundario);

                    match.Add(userSecundario);
                }
            }

            var listaSecundario = await _novoMatchAppService.ProcurarUsuarioSecundario(nome);
            if (listaSecundario != null)
            {
                foreach (var item in listaSecundario)
                {
                    var userPrimario = _userAppService.GetUserByNome(item.UsuarioPrimario);

                    match.Add(userPrimario);
                }
            }
        
            IEnumerable list = match.Select(e => e.Nome).ToList();

            ViewBag.usuarios = new SelectList(list);

            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("registrar")]
        public IActionResult Create([Bind("Criador, Membro1, Membro2, Membro3, Membro4, Membro5, Membro6, Membro7, Membro8, Membro9, Atividade, Local, Data")] AgendaViewModel agendaViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(agendaViewModel);
                }

                agendaViewModel.Criador = User.Identity.Name;
                agendaViewModel.Ativo = "1";

                _agendaAppService.Add(agendaViewModel);
                if (!OpIsValid())
                {
                    return View(agendaViewModel);
                }

                AlertToast("Atividade", "Atividade criada com sucesso!", NotificationType.Success);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
        [Route("{id}/delete")]
        public async Task<IActionResult> Delete(Guid? id)
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

            criador = agendaViewModel.Criador;

            return View(agendaViewModel);
        }

        [HttpPost, ActionName("Avaliar")]
        [Route("{id:guid}/avaliar")]
        [ValidateAntiForgeryToken]
        public IActionResult Avaliar([Bind("Id, Criador, Membro1, Membro2, Membro3, Membro4, Membro5, Membro6, Membro7, Membro8, Membro9, Atividade, Local, Data")] AgendaViewModel agendaViewModel)
        {

            _agendaAppService.Edit(agendaViewModel.Id, "0");

            NotaViewModel notaViewModel = new NotaViewModel
            {
                AgendaId = Convert.ToString(agendaViewModel.Id),
                Criador = criador,
                NotaMembro1 = agendaViewModel.Membro1,
                NotaMembro2 = agendaViewModel.Membro2,
                NotaMembro3 = agendaViewModel.Membro3,
                NotaMembro4 = agendaViewModel.Membro4,
                NotaMembro5 = agendaViewModel.Membro5,
                NotaMembro6 = agendaViewModel.Membro6,
                NotaMembro7 = agendaViewModel.Membro7,
                NotaMembro8 = agendaViewModel.Membro8,
                NotaMembro9 = agendaViewModel.Membro9
            };

            _notaAppService.Add(notaViewModel);


            AlertToast("Avaliar", "Membros avaliados com sucesso!", NotificationType.Success);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("{id}/editar")]
        public async Task<IActionResult> Edit(Guid? id)
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

            string nome = User.Identity.Name;
            IList<UserViewModel> match = new List<UserViewModel>();

            var listaPrimario = await _novoMatchAppService.ProcurarUsuarioPrimario(nome);
            if (listaPrimario != null)
            {
                foreach (var item in listaPrimario)
                {
                    var userSecundario = _userAppService.GetUserByNome(item.UsuarioSecundario);

                    match.Add(userSecundario);
                }
            }

            var listaSecundario = await _novoMatchAppService.ProcurarUsuarioSecundario(nome);
            if (listaSecundario != null)
            {
                foreach (var item in listaSecundario)
                {
                    var userPrimario = _userAppService.GetUserByNome(item.UsuarioPrimario);

                    match.Add(userPrimario);
                }
            }

            IEnumerable list = match.Select(e => e.Nome).ToList();

            ViewBag.usuarios = new SelectList(list);



            return View(agendaViewModel);
        }

        [HttpPost]
        [Route("{id}/editar")]
        public IActionResult Edit([Bind("Id, Criador, Membro1, Membro2, Membro3, Membro4, Membro5, Membro6, Membro7, Membro8, Membro9, Atividade, Local, Data")] AgendaViewModel agendaViewModel)
        {

            agendaViewModel.Criador = User.Identity.Name;
            agendaViewModel.Ativo = "1";

            if (!ModelState.IsValid)
            {
                return View(agendaViewModel);
            }

            _agendaAppService.EditarAgenda(agendaViewModel);
            if (!OpIsValid())
            {
                return View(agendaViewModel);
            }


            AlertToast("Agenda", "Atividade atualizada com sucesso!", NotificationType.Success);
            return RedirectToAction("Index");
        }
    }
}