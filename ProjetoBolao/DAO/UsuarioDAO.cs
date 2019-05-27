using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoBolao.Models;

namespace ProjetoBolao.DAO
{
    public class UsuarioDAO
    {
        public static Usuario Busca(string login, string senha)
        {
            using (var contexto = new SiteContext())
            {
                foreach (Usuario u in Lista())
                    if (u.Email == login && u.Senha == senha)
                        return u;
                return null;
            }
        }

        public static IList<Usuario> Lista()
        {
            using (var contexto = new SiteContext())
            {
                return contexto.Usuario2.ToList();
            }
        }
        public static Usuario returnUsuario(string s)
        {
            using (var contexto = new SiteContext())
            {
                return contexto.Usuario2.FirstOrDefault(u => u.Nome == s);
            }
        }

        public static Usuario returnUsuario(int id)
        {
            using (var contexto = new SiteContext())
            {
                return contexto.Usuario2.FirstOrDefault(u => u.Id == id);
            }
        }

        public static Usuario Usuario(string email)
        {
            using (var contexto = new SiteContext())
            {
                return contexto.Usuario2.FirstOrDefault(u => u.Email == email);
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

        public static void Alterar(Usuario u)
        {
            using (var contexto = new SiteContext())
            {
                contexto.Usuario2.Update(u);
                contexto.SaveChanges();
            }
        }
    }
}