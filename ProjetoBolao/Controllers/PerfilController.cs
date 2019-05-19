using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBolao.Filtros;

namespace ProjetoBolao.Controllers
{
    [AutorizacaoFilterAttribute]
    public class PerfilController : Controller
    {
        // GET: Perfil
        public ActionResult Index()
        {
            return View();
        }
    }
}