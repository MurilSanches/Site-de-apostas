using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBolao.Filtros;
using ProjetoBolao.DAO;
using ProjetoBolao.Models;

namespace ProjetoBolao.Controllers
{
    [AutorizacaoFilterAttribute]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.Usuario = Session["usuarioLogado"];
            return View();
        }

        public ActionResult AdicionaJogo()
        {
            ViewBag.Times = TimeDAO.ListarTimes();
            return View();
        }

        public ActionResult JogoNovo(Jogo j)
        {            
            j.Ocorreu = 0;
            JogoDAO.Adiciona(j);
            return RedirectToAction("AdicionaJogo", "Admin");
        }

        public ActionResult AdicionaResultado()
        {
            ViewBag.Jogos = JogoDAO.ListaJogo();
            return View();
        }

        public ActionResult AdicionarResultado(Resultado r)
        {
            Jogo j = JogoDAO.Jogo(r.CodJogo);
            j.Ocorreu = 1;
            JogoDAO.Altera(j);

            // Calculo de pontos de cada usuario
            foreach (Votacao v in VotacaoDAO.ListaDeVotosDoJogo(j.Id))
            {
                Usuario u = UsuarioDAO.returnUsuario(v.CodUsuario);

                if (r.QtdGolA > r.QtdGolB && v.CodTimeVotado == j.CodTimeA)
                    u.qntsPontos += 100;
                if (r.QtdGolA < r.QtdGolB && v.CodTimeVotado == j.CodTimeB)
                    u.qntsPontos += 100;
                if (r.QtdGolA == r.QtdGolB && v.CodTimeVotado == 0)
                    u.qntsPontos += 100;                        

                UsuarioDAO.Alterar(u);
            }

            ResultadoDAO.Adiciona(r);
            return RedirectToAction("AdicionaResultado", "Admin");
        }

        public ActionResult AlteraUsuario()
        {
            ViewBag.Usuarios = UsuarioDAO.Lista();
            return View();
        }

        public ActionResult AlteraTime()
        {
            return View();
        }

        public JsonResult UsuarioJson(string nome)
        {
            return Json(UsuarioDAO.returnUsuario(nome));
        }

        public JsonResult TimeJson(string nome)
        {
            return Json(TimeDAO.Time(nome));
        }
    }
}