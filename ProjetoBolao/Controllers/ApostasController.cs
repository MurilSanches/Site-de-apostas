using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBolao.DAO;
using ProjetoBolao.Models;
using ProjetoBolao.Filtros;

namespace ProjetoBolao.Controllers
{
    [AutorizacaoFilterAttribute]
    public class ApostasController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Jogos = JogoDAO.ListaJogo();
            Usuario u = (Usuario)Session["usuarioLogado"];
            ViewBag.Votos = VotacaoDAO.ListaDeVotosDoUsuario(u.Id);
            ViewBag.TodosOsVotos = VotacaoDAO.Lista();
            return View();
        }

        public ActionResult Votar(Votacao v)
        {            
            v.CodUsuario = ((Usuario)Session["usuarioLogado"]).Id;
            VotacaoDAO.Votar(v);               
            return RedirectToAction("Index", "Apostas");
        }
    }
}