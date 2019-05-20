using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoBolao.Models;

namespace ProjetoBolao.DAO
{
    public class JogoDAO
    {
        public IList<Jogo> ListaJogo()
        {
            using (var contexto = new SiteContext())
            {
                return contexto.Jogo.ToList<Jogo>();
            }
        }
    }
}