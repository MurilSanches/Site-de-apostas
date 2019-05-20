using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBolao.Models
{
    public class Jogo
    {
        public int CodJogo { get; set; }

        public int CodTimeA { get; set; }

        public int CodTimeB { get; set; }

        public string Resultado { get; set; }

        public int CodTimeVitorioso { get; set; }

        public bool Ocorreu { get; set; }
    }
}