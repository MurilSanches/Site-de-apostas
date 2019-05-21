using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBolao.Models
{
    public class Votacao
    {
        public int Id { get; set; }

        public int CodJogo { get; set; }

        public int CodTimeVotado { get; set; }

        public int CodUsuario { get; set; }
    }
}