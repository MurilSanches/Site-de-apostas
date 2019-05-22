using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoBolao.Models;

namespace ProjetoBolao.DAO
{
    public class VotacaoDAO
    {
        public static void Votar(Votacao v)
        {
            using (var contexto = new SiteContext())
            {
                contexto.Votacao.Add(v);
                contexto.SaveChanges();
            }
        }

        public static IList<Votacao> Lista()
        {
            using (var contexto = new SiteContext())
            {
                return contexto.Votacao.ToList();
            }
        }

        public static IList<Votacao> ListaDeVotosDoUsuario(int id)
        {
            List<Votacao> lista = new List<Votacao>();
            foreach (Votacao v in Lista())
            {
                if (v.CodUsuario == id)
                    lista.Add(v);
            }

            return lista;
        }
    }
}