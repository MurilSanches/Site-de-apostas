using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBolao.Models
{
    public class Resultado
    {
        public int Id { get; set; }

        public int CodJogo { get; set; }

        public int QtdGolA { get; set; }

        public int QtdGolB { get; set; }
    }
}