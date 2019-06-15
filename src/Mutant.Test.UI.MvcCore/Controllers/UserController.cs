using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlaySports.Application.Interfaces;
using PlaySports.Application.ViewModels;
using PlaySports.Domain.Core.Notifications;
using PlaySports.UI.MvcCore.Enums;
using X.PagedList;

namespace PlaySports.UI.MvcCore.Controllers
{
    [Authorize]
    [Route("usuarios")]
    public class UserController : BaseController
    {
        private readonly IUserAppService _userAppService;
        private static byte[] imagem;

        private static string denuncia;
        private static string idUsuario;


        public UserController(INotificationHandler<DomainNotification> notifications, IUserAppService userAppService)
            : base(notifications)
        {
            _userAppService = userAppService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index(int pagina = 1)
        {
            var users = await _userAppService.GetAllAsync();
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

            string imreBase64Dados = Convert.ToBase64String(userViewModel.Imagem);
            string imagemDadosURL = string.Format("data:image/png;base64,{0}", imreBase64Dados);
            //Passando os dados da imagem para a viewbag
            ViewBag.DadosImagem = imagemDadosURL;


            return View(userViewModel);
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("Upload")]
        public IActionResult UploadImagem(IList<IFormFile> arquivos)
        {
            IFormFile imagemEnviada = arquivos.FirstOrDefault();
            if (imagemEnviada != null || imagemEnviada.ContentType.ToLower().StartsWith("image/"))
            {
                MemoryStream ms = new MemoryStream();
                imagemEnviada.OpenReadStream().CopyTo(ms);                
                imagem = ms.ToArray();
                
            }
            return RedirectToAction("Create");
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("registrar")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("registrar")]
        public IActionResult Create([Bind("Nome, Sexo, Login, Esporte, Nivel, Localizacao, Senha, ConfirmarSenha, DataNascimento, Imagem")] RegisterUserViewModel registerUserViewModel)
        {
            registerUserViewModel.Imagem = imagem;

            if (!ModelState.IsValid)
            {
                return View(registerUserViewModel);
            }

            _userAppService.Add(registerUserViewModel);
            if (!OpIsValid())
            {
                return View(registerUserViewModel);
            }

            AlertToast("Usuário", "Usuário inserido com sucesso!", NotificationType.Success);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Editar")]
        public IActionResult EditImagem(IList<IFormFile> arquivos)
        {
            IFormFile imagemEnviada = arquivos.FirstOrDefault();
            if (imagemEnviada != null || imagemEnviada.ContentType.ToLower().StartsWith("image/"))
            {
                MemoryStream ms = new MemoryStream();
                imagemEnviada.OpenReadStream().CopyTo(ms);
                imagem = ms.ToArray();

            }
            return Redirect(idUsuario + "/editar"); 
        }


        [HttpGet]
        [Route("{id}/editar")]
        public async Task<IActionResult> Edit(Guid? id)
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

            denuncia = userViewModel.Denuncia;

            idUsuario = Convert.ToString(userViewModel.Id);

            return View(userViewModel);
        }

        [HttpPost]
        [Route("{id}/editar")]
        public IActionResult Edit([Bind("Id, Nome, Sexo, Esporte, Nivel, Localizacao, Login, DataNascimento, Imagem")] UserViewModel userViewModel)
        {

            userViewModel.Imagem = imagem;

            userViewModel.Denuncia = denuncia;



            if (!ModelState.IsValid)
            {
                return View(userViewModel);
            }

            _userAppService.Edit(userViewModel);
            if (!OpIsValid())
            {
                return View(userViewModel);
            }
            
            AlertToast("Usuário", "Usuário atualizado com sucesso!", NotificationType.Success);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("{id}/alterar-senha")]
        public IActionResult ChangePassword(Guid? id)
        {
            return View();
        }

        [HttpPost]
        [Route("{id}/alterar-senha")]
        public IActionResult ChangePassword([Bind("Id, SenhaAtual, NovaSenha, ConfirmarNovaSenha")] ChangeUserPasswordViewModel changePasswordViewModel)
        {
            return View();
        }


        [HttpGet]
        [Route("{id}/remover")]
        public async Task<IActionResult> Delete(Guid? id)
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

            return View(userViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Route("{id:guid}/remover")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _userAppService.Delete(id);

            if (!OpIsValid())
            {
                return View(await _userAppService.GetUserByIdAsync(id));
            }

            AlertToast("Usuário", "Usuário removido com sucesso!", NotificationType.Success);
            return RedirectToAction("Index");
        }
    }
}