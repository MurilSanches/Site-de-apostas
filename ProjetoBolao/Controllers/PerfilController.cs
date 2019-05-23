using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBolao.Filtros;
using ProjetoBolao.Models;

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
    }
}