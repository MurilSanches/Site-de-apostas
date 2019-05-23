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

        public ActionResult JogoNovo(int id1, int id2)
        {
            JogoDAO.Adiciona(id1, id2);
            return RedirectToAction("AdicionaJogo", "Admin");
        }

        public ActionResult AdicionaResultado()
        {
            ViewBag.Jogos = JogoDAO.ListaJogo();
            return View();
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
    }
}