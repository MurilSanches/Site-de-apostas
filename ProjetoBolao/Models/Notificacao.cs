using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBolao.Models
{
    public class Notificacao
    {
        public int Id { get; set; }
        public int pontosGanhos { get; set; }

        public DateTime data { get; set; }

        public int CodJogo { get; set; }

        public int CodUsuario { get; set; }
    } 
}