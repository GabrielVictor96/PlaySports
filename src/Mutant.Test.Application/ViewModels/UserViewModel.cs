using System;
using System.ComponentModel.DataAnnotations;
using PlaySports.Domain.Core.Enums;

namespace PlaySports.Application.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Sexo")]
        public Sexo Sexo { get; set; }

        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Nome de usuário")]
        public string Login { get; set; }

        [Display(Name = "Esporte")]
        public string Esporte { get; set; }

        [Display(Name = "Nível")]
        public string Nivel { get; set; }

        [Display(Name = "Localização")]
        public string Localizacao { get; set; }

        [Display(Name = "Imagem")]
        public byte[] Imagem { get; set; }

        [Display(Name = "Denúncia")]
        public string Denuncia { get; set; }
    }
}