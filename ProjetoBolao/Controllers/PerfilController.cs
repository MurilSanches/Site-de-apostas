using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBolao.Filtros;
using ProjetoBolao.Models;
using ProjetoBolao.DAO;
using System.IO;

namespace ProjetoBolao.Controllers
{
    [AutorizacaoFilterAttribute]
    public class PerfilController : Controller
    {
        // GET: Perfil
        public ActionResult Index()
        {
            Usuario u = (Usuario)Session["usuarioLogado"];
            ViewBag.Usuario = u;
            if (u.Id == 1)
                return RedirectToAction("Index", "Admin");
            return View();
        }

        public ActionResult AlteraEmail(Usuario u)
        {
            Usuario user = UsuarioDAO.returnUsuario(u.Id);

            user.Email = u.Email;

            UsuarioDAO.Alterar(user);

            Session["usuarioLogado"] = user;

            return RedirectToAction("Index", "Perfil");
        }

        [HttpPost]
        public ActionResult AlteraFoto(Usuario u, HttpPostedFileBase upload)
        {
            Usuario user = UsuarioDAO.returnUsuario(u.Id);

            if (upload != null)
            {
                var uploadPath = Server.MapPath("~/img/imgUsuarios");
                string caminhoArq = Path.Combine(@uploadPath, user.Nome + Path.GetExtension(upload.FileName));

                string[] extensaoPermitida = { ".gif", ".png", ".jpg", ".jpeg" };

                for (int i = 0; i < extensaoPermitida.Length; i++)
                    if (Path.GetExtension(caminhoArq) == extensaoPermitida[i])
                    {
                        upload.SaveAs(caminhoArq);
                        break;
                    }
                user.Foto = "../img/imgUsuarios/" + user.Nome + Path.GetExtension(upload.FileName);
            }

            UsuarioDAO.Alterar(user);
            Session["usuarioLogado"] = user;

            return RedirectToAction("Index", "Perfil");
        }

        public ActionResult AlteraNome(Usuario u)
        {
            Usuario user = UsuarioDAO.returnUsuario(u.Id);

            user.Nome = u.Nome;

            UsuarioDAO.Alterar(user);

            Session["usuarioLogado"] = user;

            return RedirectToAction("Index", "Perfil");
        }

        public ActionResult AlteraSenha(Usuario u)
        {
            Usuario user = UsuarioDAO.returnUsuario(u.Id);

            user.Senha = u.Senha;

            UsuarioDAO.Alterar(user);

            Session["usuarioLogado"] = user;

            return RedirectToAction("Index", "Perfil");
        }
    }
}