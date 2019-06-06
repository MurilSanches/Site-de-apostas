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

        public static IList<Jogo> JogosMaisVotados()
        {
            using (var contexto = new SiteContext())
            {
                var list = new List<Jogo>();
                Jogo jogoMaisVotado = null;
                var todosJogos = ListaJogo();

                if (todosJogos.Count == 3)
                    return todosJogos;
                do
                {
                    foreach (Jogo j in todosJogos)
                    {
                        if (j.Ocorreu == 1)
                            continue;
                        if (jogoMaisVotado == null)
                            jogoMaisVotado = j;
                        else
                        if (j.QtdVotos > jogoMaisVotado.QtdVotos)
                            jogoMaisVotado = j;                        
                    }                    

                    todosJogos.Remove(jogoMaisVotado);
                    list.Add(jogoMaisVotado);
                    jogoMaisVotado = null;
                }
                while (list.Count < 3);

                return list;
            }
        }

        public static void Adiciona(int id1, int id2)
        {
            using (var contexto = new SiteContext())
            {
                Jogo j = new Jogo();
                j.CodTimeA = id1;
                j.CodTimeB = id2;
                j.Ocorreu = 0;

                contexto.Jogo.Add(j);
                contexto.SaveChanges();
            }
        }

        public static void Adiciona(string nomeA, string nomeB)
        {
            using (var contexto = new SiteContext())
            {
                Jogo j = new Jogo();
                j.CodTimeA = TimeDAO.Time(nomeA).Id;
                j.CodTimeB = TimeDAO.Time(nomeB).Id;
                j.Ocorreu = 0;

                contexto.Jogo.Add(j);
                contexto.SaveChanges();
            }
        }

        public static void Altera(Jogo j)
        {
            using (var contexto = new SiteContext())
            {
                contexto.Jogo.Update(j);
                contexto.SaveChanges();
            }
        }

        public static void Adiciona(Jogo j)
        {
            using (var contexto = new SiteContext())
            {
                contexto.Jogo.Add(j);
                contexto.SaveChanges();
            }
        }

        public static Jogo Jogo(int id)
        {
            using (var contexto = new SiteContext())
            {
                return contexto.Jogo.FirstOrDefault(u => u.Id == id);
            }
        }

        public static IList<Jogo> JogosTimes(string nome)
        {
            using (var contexto = new SiteContext())
            {
                var list = new List<Jogo>();
                var todosJogos = ListaJogo();

                foreach (Jogo j in todosJogos)
                {
                    var timeA = TimeDAO.Time(j.CodTimeA);
                    var timeB = TimeDAO.Time(j.CodTimeB);

                    if (timeA.NomeTime == nome || timeB.NomeTime == nome)
                        list.Add(j);
                }

                return list;
            }
        }

        public static IList<Time> Time(Jogo j)
        {
            using(var contexto = new SiteContext())
            {
                var list = new List<Time>();
                var todosJogos = ListaJogo();
                                
                list.Add(TimeDAO.Time(j.CodTimeA));
                list.Add(TimeDAO.Time(j.CodTimeB));                    

                return list;
            }
        }
    }
}