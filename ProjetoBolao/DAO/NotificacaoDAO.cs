using ProjetoBolao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBolao.DAO
{
    public class NotificacaoDAO
    {
        public static IList<Notificacao> Lista()
        {
            using (var contexto = new SiteContext())
            {
                return contexto.Notificacao.ToList();
            }
        }
        
        public static IList<Notificacao> Lista(int id)
        {
            using (var contexto = new SiteContext())
            {
                var list = new List<Notificacao>();
                foreach (Notificacao n in Lista())
                    if (n.CodUsuario == id)
                        list.Add(n);
                return list;                
            }
        }

        public static void Adicionar(Notificacao n)
        {
            using (var contexto = new SiteContext())
            {
                contexto.Notificacao.Add(n);
                contexto.SaveChanges();
            }
        }
    }
}