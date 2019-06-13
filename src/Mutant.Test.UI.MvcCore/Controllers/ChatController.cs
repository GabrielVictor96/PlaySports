using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlaySports.Application.Interfaces;
using PlaySports.Application.ViewModels;
using PlaySports.Domain.Core.Notifications;
using PlaySports.UI.MvcCore.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace PlaySports.Controllers
{

    [Authorize]
    [Route("chat")]
    public class ChatController : BaseController
    {
        private readonly IUserAppService _userAppService;
        private readonly IMatchAppService _matchAppService;
        private readonly INovoMatchAppService _novoMatchAppService;

        public ChatController(INotificationHandler<DomainNotification> notifications, IUserAppService userAppService, IMatchAppService matchAppService, INovoMatchAppService novoMatchAppService)
          : base(notifications)
        {
            _userAppService = userAppService;
            _matchAppService = matchAppService;
            _novoMatchAppService = novoMatchAppService;
        }



        [HttpGet]
        [Route("inicial")]
        public async Task<IActionResult> Index(int pagina = 1)
        {
            string nome = User.Identity.Name;
            var match = new List<UserViewModel>();


            var listaPrimario = await _novoMatchAppService.ProcurarUsuarioPrimario(nome);
            if(listaPrimario!=null)
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


            return View(new PagedList<UserViewModel>(match, pagina, 10));
        }

        [HttpGet]
        [Route("{id}/details")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var userViewModel = await _userAppService.GetUserByIdAsync(id.Value);
            if (userViewModel == null)
            {
                return NotFound();
            }

            string imreBase64Dados = Convert.ToBase64String(userViewModel.Imagem);
            string imagemDadosURL = string.Format("data:image/png;base64,{0}", imreBase64Dados);
            //Passando os dados da imagem para a viewbag
            ViewBag.DadosImagem = imagemDadosURL;

            ViewBag.Nome = userViewModel.Nome;


            return View();
        }

        [HttpGet]
        [Route("{id}/delete")]
        public ActionResult Delete(Guid? id)
        {







            return View();
        }
    }
}