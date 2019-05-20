using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBolao.DAO;

namespace Projeto2BOlao.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sobre()
        {
            return View();
        }

        public ActionResult Apostas()
        {
            JogoDAO dao = new JogoDAO();
            ViewBag.Jogos = dao.ListaJogo();
            return View();
        }
    }
}