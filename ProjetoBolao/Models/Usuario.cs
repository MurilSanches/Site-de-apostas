using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBolao.Models
{
    public class Usuario
    {
        public int CodUsuario { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }

        public int qntsPontos { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }
    }
}