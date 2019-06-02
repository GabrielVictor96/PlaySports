using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlaySports.Application.Interfaces;
using PlaySports.Application.ViewModels;
using PlaySports.Domain.Core.Notifications;
using PlaySports.UI.MvcCore.Enums;

namespace PlaySports.UI.MvcCore.Controllers
{
    [Route("minha-conta")]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationAppService _authenticationAppService;
        private readonly IConfiguration _configuration;

        public AuthenticationController(INotificationHandler<DomainNotification> notifications, IAuthenticationAppService authenticationAppService, IConfiguration configuration)
            : base(notifications)
        {
            _authenticationAppService = authenticationAppService;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("entrar")]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [Route("entrar")]
        public async Task<IActionResult> Login([Bind("Login, Senha, ReturnUrl")] LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var (isAuthorized, userViewModel) = await _authenticationAppService.ValidateLogin(loginViewModel);
            if (!isAuthorized)
            {
                AlertToast("Login", "Usuário ou senha inválidos!", NotificationType.Info);
                return View(loginViewModel);
            }

            await LoginAsync(userViewModel, loginViewModel.LembrarMe);
            if (IsUrlValid(loginViewModel.ReturnUrl))
            {
                return Redirect(loginViewModel.ReturnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("sair")]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (!_configuration.GetValue<bool>("Account:ShowLogoutPrompt"))
            {
                return await Logout();
            }

            return View();
        }

        [HttpPost]
        [Route("sair")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            return RedirectToAction("Index", "Home");
        }

        private static bool IsUrlValid(string returnUrl)
        {
            return !string.IsNullOrWhiteSpace(returnUrl) && Uri.IsWellFormedUriString(returnUrl, UriKind.Relative);
        }

        private async Task LoginAsync(UserViewModel userViewModel, bool isPersistent)
        {
            var properties = new AuthenticationProperties
            {
                AllowRefresh = false,
                IsPersistent = isPersistent,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
            };

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userViewModel.Id.ToString()),
                new Claim(ClaimTypes.Name, userViewModel.Nome),
                new Claim(ClaimTypes.DateOfBirth, userViewModel.DataNascimento.ToString("o"), ClaimValueTypes.DateTime)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal, properties);
        }
    }
}