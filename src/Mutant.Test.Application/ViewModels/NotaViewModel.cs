using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlaySports.Application.ViewModels
{
    public class NotaViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Agenda")]
        public string AgendaId { get; set; }

        [Display(Name = "Criador")]
        public string Criador { get; set; }

        [Display(Name = "Nota Membro 1")]
        public string NotaMembro1 { get; set; }

        [Display(Name = "Nota Membro 2")]
        public string NotaMembro2 { get; set; }

        [Display(Name = "Nota Membro 3")]
        public string NotaMembro3 { get; set; }

        [Display(Name = "Nota Membro 4")]
        public string NotaMembro4 { get; set; }

        [Display(Name = "Nota Membro 5")]
        public string NotaMembro5 { get; set; }

        [Display(Name = "Nota Membro 6")]
        public string NotaMembro6 { get; set; }

        [Display(Name = "Nota Membro 7")]
        public string NotaMembro7 { get; set; }

        [Display(Name = "Nota Membro 8")]
        public string NotaMembro8 { get; set; }

        [Display(Name = "Nota Membro 9")]
        public string NotaMembro9 { get; set; }
    }
}
