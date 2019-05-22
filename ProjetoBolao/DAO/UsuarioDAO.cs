using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoBolao.Models;

namespace ProjetoBolao.DAO
{
    public class UsuarioDAO
    {
        public Usuario Busca(string login, string senha)
        {
            using (var contexto = new SiteContext())
            {
                return contexto.Usuario2.FirstOrDefault(u => u.Nome == login && u.Senha == senha);
            }
        }

        public static IList<Usuario> Lista()
        {
            using (var contexto = new SiteContext())
            {
                return contexto.Usuario2.ToList();
            }
        }

        public static void Adicionar (Usuario u)
        {
            using (var contexto = new SiteContext())
            {
                contexto.Usuario2.Add(u);
                contexto.SaveChanges();
            }
        }
    }
}