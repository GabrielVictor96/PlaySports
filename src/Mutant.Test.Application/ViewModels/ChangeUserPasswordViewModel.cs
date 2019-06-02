using System;
using System.ComponentModel.DataAnnotations;

namespace PlaySports.Application.ViewModels
{
    public class ChangeUserPasswordViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Senha atual")]
        [Required(ErrorMessage = "Campo senha atual é obrigatório!")]
        public string SenhaAtual { get; set; }

        [Display(Name = "Nova senha")]
        [Required(ErrorMessage = "Campo nova senha é obrigatório!")]
        public string NovaSenha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Senha", ErrorMessage = "A nova senha e a confirmação não são iguais.")]
        public string ConfirmarNovaSenha { get; set; }
    }
}