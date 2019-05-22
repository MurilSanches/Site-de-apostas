using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBolao.DAO;

namespace ProjetoBolao.Controllers
{
    public class RankingController : Controller
    {
        // GET: Ranking
        public ActionResult Index()
        {
            ViewBag.Usuarios = UsuarioDAO.Lista();
            return View();
        }
    }
}