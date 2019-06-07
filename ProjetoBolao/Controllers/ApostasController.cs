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

    public class ApostasController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Jogos = JogoDAO.ListaJogo();
            Usuario u = (Usuario)Session["usuarioLogado"];
            if(u != null)
                ViewBag.Votos = VotacaoDAO.ListaDeVotosDoUsuario(u.Id);
            ViewBag.TodosOsVotos = VotacaoDAO.Lista();
            return View();
        }

        public JsonResult Votar(int idJogo, int idTime, int posicao)
        {
            Votacao v = new Votacao();
            Session["posicao"] = posicao;
            v.CodTimeVotado = idTime;
            v.CodJogo = idJogo;
            v.CodUsuario = ((Usuario)Session["usuarioLogado"]).Id;

            VotacaoDAO.Votar(v);

            Jogo j = JogoDAO.Jogo(v.CodJogo);
            j.QtdVotos += 1;
            if (v.CodTimeVotado == 0)
                j.QtdVotosEmpate += 1;
            else
            {
                if (v.CodTimeVotado == j.CodTimeA)
                    j.QtdVotosTimeA += 1;
                else
                    j.QtdVotosTimeB += 1;
            }
            JogoDAO.Altera(j);
            return Json(true);
        }

        public JsonResult Time(Jogo j)
        {
            return Json(JogoDAO.Time(j));
        }

        [HttpPost]
        public JsonResult JogoTime(string nomeTime)
        {
            return Json(JogoDAO.JogosTimes(nomeTime));
        }
        
        [HttpPost]
        public JsonResult TodosJogos()
        {
            return Json(JogoDAO.ListaJogo());
        }

        [HttpPost]
        public JsonResult Votos()
        {
            return Json(VotacaoDAO.Lista());
        }

        [HttpPost]
        public JsonResult VotoDoUsuario(int id)
        {
            return Json(VotacaoDAO.ListaDeVotosDoUsuario(id));
        }


        [HttpPost]
        public JsonResult Usuario()
        {
            return Json((Usuario)Session["usuarioLogado"]);
        }
    }
}