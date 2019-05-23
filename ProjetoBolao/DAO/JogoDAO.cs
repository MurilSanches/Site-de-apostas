using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoBolao.Models;

namespace ProjetoBolao.DAO
{
    public class JogoDAO
    {
        public static IList<Jogo> ListaJogo()
        {
            using (var contexto = new SiteContext())
            {
                return contexto.Jogo.ToList();
            }
        }

        public static void Adiciona(int id1, int id2)
        {
            using (var contexto = new SiteContext())
            {
                Jogo j = new Jogo();
                j.CodTimeA = id1;
                j.CodTimeB = id2;
                j.Ocorreu  = 0;

                contexto.Jogo.Add(j);
                contexto.SaveChanges();
            }
        }
    }
}