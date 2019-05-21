using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoBolao.Models;

namespace ProjetoBolao.DAO
{
    public class VotacaoDAO
    {
        public static void Votar(int idTime, int idJogo, Usuario u)
        {
            using (var contexto = new SiteContext())
            {
                Votacao v = new Votacao();
                
                v.CodTimeVotado = idTime;
                v.CodJogo = idJogo;
                v.CodUsuario = u.Id;

                contexto.Votacao.Add(v);
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
                if (v.Id == id)
                    lista.Add(v);
            }

            return lista;
        }
    }
}