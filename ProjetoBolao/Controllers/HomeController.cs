using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBolao.DAO;
using ProjetoBolao.Models;

namespace ProjetoBolao.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Jogos = JogoDAO.JogosMaisVotados();
            Usuario u = (Usuario)Session["usuarioLogado"];
            if(u != null)
                ViewBag.Votos = VotacaoDAO.ListaDeVotosDoUsuario(u.Id);
            ViewBag.TodosOsVotos = VotacaoDAO.Lista();
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