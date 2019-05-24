using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoBolao.Models;

namespace ProjetoBolao.DAO
{
    public class ResultadoDAO
    {
        public static void Adiciona(Resultado r)
        {
            using (var contexto = new SiteContext())
            {
                contexto.Resultado.Add(r);
                contexto.SaveChanges();
            }
        }
    }
}