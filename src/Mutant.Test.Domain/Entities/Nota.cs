using PlaySports.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Domain.Entities
{
    public class Nota : Entity
    {
        protected Nota() { }

        public Nota(string agendaId, string criador, string notaMembro1, string notaMembro2, string notaMembro3, string notaMembro4, string notaMembro5, string notaMembro6, string notaMembro7, string notaMembro8, string notaMembro9)
        {
            AgendaId = agendaId;
            Criador = criador;
            NotaMembro1 = notaMembro1;
            NotaMembro2 = notaMembro2;
            NotaMembro3 = notaMembro3;
            NotaMembro4 = notaMembro4;
            NotaMembro5 = notaMembro5;
            NotaMembro6 = notaMembro6;
            NotaMembro7 = notaMembro7;
            NotaMembro8 = notaMembro8;
            NotaMembro9 = notaMembro9;
        }

        public string AgendaId { get; private set; }
        public string Criador { get; private set; }
        public string NotaMembro1 { get; private set; }
        public string NotaMembro2 { get; private set; }
        public string NotaMembro3 { get; private set; }
        public string NotaMembro4 { get; private set; }
        public string NotaMembro5 { get; private set; }
        public string NotaMembro6 { get; private set; }
        public string NotaMembro7 { get; private set; }
        public string NotaMembro8 { get; private set; }
        public string NotaMembro9 { get; private set; }

    }
}
