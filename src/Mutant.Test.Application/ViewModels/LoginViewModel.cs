using System.ComponentModel.DataAnnotations;

namespace PlaySports.Application.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name="Lembrar-me")]
        public bool LembrarMe { get; set; }

        public string ReturnUrl { get; set; }

    }
}