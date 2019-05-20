using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBolao.DAO;
using ProjetoBolao.Models;

namespace ProjetoBolao.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autentica(Usuario u)
        {   
            UsuarioDAO dao = new UsuarioDAO();
            Usuario usu = dao.Busca(u.Nome, u.Senha);

            if (usu != null)
            {
                Session["usuarioLogado"] = usu;
                return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("Index");
        }
    }
}