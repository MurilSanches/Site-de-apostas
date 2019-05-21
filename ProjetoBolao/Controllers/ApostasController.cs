using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBolao.DAO;
using ProjetoBolao.Models;

namespace ProjetoBolao.Controllers
{
    public class ApostasController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Jogos = JogoDAO.ListaJogo();

            Usuario u = (Usuario)Session["usuarioLogado"];

            if (u != null)
            {
                ViewBag.Votos = VotacaoDAO.ListaDeVotosDoUsuario(u.Id);        
            }
            return View();
        }

        public ActionResult Votar(int idTime, int idJogo)
        {
            if (Session["usuarioLogado"] == null)
            {
                return RedirectToAction("Index", "Apostas");
            }
            else
            {
                Usuario u=(Usuario)Session["usuarioLogado"];
                VotacaoDAO.Votar(idTime, idJogo, u);               
                return RedirectToAction("Index", "Apostas");
            }

        }
    }
}