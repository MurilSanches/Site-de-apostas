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

        public JsonResult Autentica(string email, string senha)
        {   
            Usuario usu = UsuarioDAO.Busca(email, senha);

            if (usu != null)
            {
                Session["usuarioLogado"] = usu;
                return Json("Logado");
            }
            else
                return Json("Erro");
        }
    }
}