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
    }
}