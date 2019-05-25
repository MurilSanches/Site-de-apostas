using ProjetoBolao.DAO;
using ProjetoBolao.Filtros;
using ProjetoBolao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBolao.Controllers
{
    [AutorizacaoFilterAttribute]
    public class NotificacaoController : Controller
    {
        // GET: Notificacao
        public ActionResult Index()
        {
            ViewBag.Notificacoes = NotificacaoDAO.Lista(((Usuario)Session["usuarioLogado"]).Id);
            return View();
        }
    }
}