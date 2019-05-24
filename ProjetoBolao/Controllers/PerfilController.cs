using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBolao.Filtros;
using ProjetoBolao.Models;
using ProjetoBolao.DAO;

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

        public JsonResult AlteraEmail(string email, int id)
        {
            Usuario user = UsuarioDAO.returnUsuario(id);

            user.Email = email;

            UsuarioDAO.Alterar(user);

            return Json("email alterado com sucesso");
        }
    }
}