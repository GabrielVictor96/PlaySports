using System;
using System.ComponentModel.DataAnnotations;
using PlaySports.Domain.Core.Enums;

namespace PlaySports.Application.ViewModels
{
    public class RegisterUserViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo nome é obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Campo sexo é obrigatório!")]
        public Sexo Sexo { get; set; }

        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo data de nascimento é obrigatório!")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Nome de usuário")]
        [Required(ErrorMessage = "Campo nome de usuário é obrigatório!")]
        public string Login { get; set; }

        [Display(Name = "Esporte")]
        [Required(ErrorMessage = "Campo esporte é obrigatório!")]
        public string Esporte { get; set; }

        [Display(Name = "Nível")]
        [Required(ErrorMessage = "Campo nível é obrigatório!")]
        public string Nivel { get; set; }

        [Display(Name = "Localização")]
        [Required(ErrorMessage = "Localização é obrigatório!")]
        public string Localizacao { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo senha é obrigatório!")]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Senha", ErrorMessage = "A senha e a confirmação da senha não são iguais.")]
        public string ConfirmarSenha { get; set; }

        [Display(Name = "Imagem")]
        public byte[] Imagem { get; set; }
    }
}