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

        public JsonResult Cadastrar(string nome, int idade, string email, string senha)
        {
            if (UsuarioDAO.Usuario(email) != null)
                return Json("Email ja cadastrado");

            Usuario u = new Usuario();

            u.Nome = nome;
            u.Idade = idade;
            u.Email = email;
            u.Senha = senha;
            u.Foto = "../img/icone.png";

            UsuarioDAO.Adicionar(u);
            Session["usuarioLogado"] = u;

            return Json("Cadastrado");

        }
    }
}