using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBolao.Models
{
    public class Time
    {
        public int Id { get; set; }
        
        public string NomeTime { get; set; }

        public string Foto { get; set; }

        public int QntsVitorias { get; set; }

        public int QntsDerrotas { get; set; }

        public int QntsEmpates { get; set; }

        public int SaldoDeGols { get; set; }

        public int Pontuacao { get; set; }
    }
}