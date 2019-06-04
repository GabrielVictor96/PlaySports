using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlaySports.Application.Interfaces;
using PlaySports.Application.ViewModels;
using PlaySports.Domain.Core.Notifications;
using PlaySports.UI.MvcCore.Controllers;
using PlaySports.UI.MvcCore.Enums;
using System;
using System.Threading.Tasks;
using X.PagedList;

namespace PlaySports.Controllers
{

    [Authorize]
    [Route("match")]
    public class MatchController : BaseController
    {
        private readonly IUserAppService _userAppService;
        private readonly IMatchAppService _matchAppService;
        private readonly INovoMatchAppService _novoMatchAppService;
        private static string usuario;


        public MatchController(INotificationHandler<DomainNotification> notifications, IUserAppService userAppService, IMatchAppService matchAppService, INovoMatchAppService novoMatchAppService)
            : base(notifications)
        {
            _userAppService = userAppService;
            _matchAppService = matchAppService;
            _novoMatchAppService = novoMatchAppService;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index(int pagina = 1)
        {
            string nome = User.Identity.Name;

            var userAtual = _userAppService.GetUserByNome(nome);
        
            var users = await _userAppService.Match(userAtual.Localizacao,userAtual.Esporte);

            foreach (var data in users)
            {
                string idade = CalculaIdade(data.DataNascimento, DateTime.Now);
                
                data.DataNascimento = Convert.ToDateTime(idade + "/11/2019");
            }
         
            return View(new PagedList<UserViewModel>(users, pagina, 10));
        }


        [HttpGet]
        [Route("{id}")]
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

            usuario = userViewModel.Nome;

            string imreBase64Dados = Convert.ToBase64String(userViewModel.Imagem);
            string imagemDadosURL = string.Format("data:image/png;base64,{0}", imreBase64Dados);
            //Passando os dados da imagem para a viewbag
            ViewBag.DadosImagem = imagemDadosURL;

            ViewBag.Nome = userViewModel.Nome;

            string idade = CalculaIdade(userViewModel.DataNascimento, DateTime.Now);

            ViewBag.Idade = idade;

            return View(userViewModel);
        }




        [HttpGet]
        [AllowAnonymous]
        [Route("Curtir")]
        public IActionResult Curtir(MatchViewModel matchViewModel)
        {
            try
            {   
                matchViewModel.UsuarioCurtiu = User.Identity.Name;
                matchViewModel.UsuarioCurtido = usuario;

                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }

                _matchAppService.AddMatch(matchViewModel);

                if (!OpIsValid())
                {
                    return RedirectToAction("Index");
                }


                var procurarMatch = _matchAppService.ProcurarMatch(matchViewModel.UsuarioCurtido, matchViewModel.UsuarioCurtiu);

                

                if (procurarMatch != null)
                {
                    
                    NovoMatchViewModel _novoMatchViewModel = new NovoMatchViewModel
                    {
                        UsuarioPrimario = procurarMatch.UsuarioCurtido,
                        UsuarioSecundario = procurarMatch.UsuarioCurtiu
                    };


                    _novoMatchAppService.AddNovoMatch(_novoMatchViewModel);


                    AlertToast("Novo Match!!!", "Entre no chat e converse com o seu novo match!", NotificationType.Success);
                    return RedirectToAction("Index");
                }

                AlertToast("Match", "Usuário curtido com sucesso!", NotificationType.Success);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        private string CalculaIdade(DateTime dNascimento, DateTime dAtual)
        {
            try
            {
            int idAnos = 0;
            DateTime dNascimentoCorrente = DateTime.Parse(dNascimento.Day.ToString() + "/" +
            dNascimento.Month.ToString() + "/" + (dAtual.Year - 1).ToString());

            idAnos = dAtual.Year - dNascimento.Year;
            if (dAtual.Month < dNascimento.Month || (dAtual.Month ==
            dNascimento.Month && dAtual.Day < dNascimento.Day))
            {
                idAnos--;
            }
                     return Convert.ToString(idAnos);
            }
            catch (Exception)
            {
                     return Convert.ToString(dNascimento);
            }
        }
    }
}