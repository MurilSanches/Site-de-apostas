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
            ViewBag.Jogos = JogoDAO.JogosMaisVotados();
            return View();
        }

        public ActionResult Sair()
        {
            Session["usuarioLogado"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Sobre()
        {
            return View();
        }

        public ActionResult Grafico()
        {
            return View();
        }
    }
}