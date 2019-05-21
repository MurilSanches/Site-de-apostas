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
            ViewBag.Jogos = JogoDAO.ListaJogo();
            return View();
        }

        public ActionResult Sobre()
        {
            return View();
        }
    }
}