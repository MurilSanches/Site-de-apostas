using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBolao.Models
{
    public class Time
    {
        public int Id { get; set; }
        
        public string Nome { get; set; }

        public string Foto { get; set; }

        public int QntVitorias { get; set; }

        public int QntDerrotas { get; set; }

        public int QntEmpates { get; set; }

        public int SaldoDeGols { get; set; }

        public int Pontuacao { get; set; }
    }
}