using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBolao.Models;
using ProjetoBolao.DAO;

namespace ProjetoBolao.Controllers
{
    public class CadastroController : Controller
    {
        // GET: Cadastro
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar(Usuario u, string data)
        {
            if (u != null)
            {
                u.qntsPontos = default(int);
                var idade = data;
                var dia = int.Parse(idade.Substring(0, 2));
                var mes = int.Parse(idade.Substring(3, 2));
                var ano = int.Parse(idade.Substring(6, 4));

                ano = DateTime.Now.Year - ano;
                if (DateTime.Now.Month < mes || (DateTime.Now.Month == mes && DateTime.Now.Day < dia))
                    ano--;

                u.Idade = ano;

                UsuarioDAO.Adicionar(u);
                Session["usuarioLogado"] = u;
                return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("Index");
        
        }
    }
}