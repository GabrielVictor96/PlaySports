using PlaySports.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaySports.Domain.Entities
{
    public class Agenda : Entity
    {
        protected Agenda() { }

        public Agenda(string criador, string membro1, string membro2, string membro3, string membro4, string membro5, string membro6, string membro7, string membro8, string membro9, string atividade, string local, DateTime data, string ativo)
        {
            Criador = criador;
            Membro1 = membro1;
            Membro2 = membro2;
            Membro3 = membro3;
            Membro4 = membro4;
            Membro5 = membro5;
            Membro6 = membro6;
            Membro7 = membro7;
            Membro8 = membro8;
            Membro9 = membro9;
            Atividade = atividade;
            Local = local;
            Data = data;
            Ativo = ativo;
        }

        public string Criador { get; private set; }
        public string Membro1 { get; private set; }
        public string Membro2 { get; private set; }
        public string Membro3 { get; private set; }
        public string Membro4 { get; private set; }
        public string Membro5 { get; private set; }
        public string Membro6 { get; private set; }
        public string Membro7 { get; private set; }
        public string Membro8 { get; private set; }
        public string Membro9 { get; private set; }
        public string Atividade { get; private set; }
        public string Local { get; private set; }
        public DateTime Data { get; private set; }
        public string Ativo { get; private set; }

    }
}
