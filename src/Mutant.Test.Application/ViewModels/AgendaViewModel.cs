using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlaySports.Application.ViewModels
{
    public class AgendaViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Criador")]
        public string Criador { get; set; }

        [Display(Name = "Membro 1")]
        public string Membro1 { get; set; }

        [Display(Name = "Membro 2")]
        public string Membro2 { get; set; }

        [Display(Name = "Membro 3")]
        public string Membro3 { get; set; }

        [Display(Name = "Membro 4")]
        public string Membro4 { get; set; }

        [Display(Name = "Membro 5")]
        public string Membro5 { get; set; }

        [Display(Name = "Membro 6")]
        public string Membro6 { get; set; }

        [Display(Name = "Membro 7")]
        public string Membro7 { get; set; }

        [Display(Name = "Membro 8")]
        public string Membro8 { get; set; }

        [Display(Name = "Membro 9")]
        public string Membro9 { get; set; }

        [Display(Name = "Atividade")]
        public string Atividade { get; set; }

        [Display(Name = "Local")]
        public string Local { get; set; }

        [Display(Name = "Data Atividade")]
        [DataType(DataType.DateTime)]
        public DateTime Data { get; set; }

        [Display(Name = "Ativo")]
        public string Ativo { get; set; }
    }
}
