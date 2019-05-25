using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoBolao.Filtros;
using ProjetoBolao.DAO;
using ProjetoBolao.Models;
using System.IO;

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
                Notificacao n = new Notificacao();

                n.pontosGanhos = u.qntsPontos;

                if (r.QtdGolA > r.QtdGolB && v.CodTimeVotado == j.CodTimeA)
                {
                    if(j.QtdVotosTimeA >= j.QtdVotosTimeB && j.QtdVotosTimeA >= j.QtdVotosEmpate)
                        u.qntsPontos += 100;
                    if (j.QtdVotosTimeA > j.QtdVotosTimeB && j.QtdVotosTimeA < j.QtdVotosEmpate)
                        u.qntsPontos += 300;
                    if (j.QtdVotosTimeA < j.QtdVotosTimeB && j.QtdVotosTimeA > j.QtdVotosEmpate)
                        u.qntsPontos += 300;
                    if (j.QtdVotosTimeA < j.QtdVotosTimeB && j.QtdVotosTimeA < j.QtdVotosEmpate)
                        u.qntsPontos += 500;
                }
                if (r.QtdGolA < r.QtdGolB && v.CodTimeVotado == j.CodTimeB)
                {
                    if (j.QtdVotosTimeB >= j.QtdVotosTimeA && j.QtdVotosTimeB >= j.QtdVotosEmpate)
                        u.qntsPontos += 100;
                    if (j.QtdVotosTimeB > j.QtdVotosTimeA && j.QtdVotosTimeB < j.QtdVotosEmpate)
                        u.qntsPontos += 300;
                    if (j.QtdVotosTimeB < j.QtdVotosTimeA && j.QtdVotosTimeB > j.QtdVotosEmpate)
                        u.qntsPontos += 300;
                    if (j.QtdVotosTimeB < j.QtdVotosTimeA && j.QtdVotosTimeB < j.QtdVotosEmpate)
                        u.qntsPontos += 500;
                }
                if (r.QtdGolA == r.QtdGolB && v.CodTimeVotado == 0)
                {
                    if (j.QtdVotosEmpate >= j.QtdVotosTimeA && j.QtdVotosEmpate >= j.QtdVotosTimeB)
                        u.qntsPontos += 100;
                    if (j.QtdVotosEmpate > j.QtdVotosTimeA && j.QtdVotosEmpate < j.QtdVotosTimeB)
                        u.qntsPontos += 300;
                    if (j.QtdVotosEmpate < j.QtdVotosTimeA && j.QtdVotosEmpate > j.QtdVotosTimeB)
                        u.qntsPontos += 300;
                    if (j.QtdVotosEmpate < j.QtdVotosTimeA && j.QtdVotosEmpate < j.QtdVotosTimeB)
                        u.qntsPontos += 500;
                }

                n.pontosGanhos = u.qntsPontos - n.pontosGanhos;
                n.data = DateTime.Now;
                n.CodJogo = j.Id;
                n.CodUsuario = u.Id;

                NotificacaoDAO.Adicionar(n);
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

        public ActionResult AlteraSenha(Usuario u)
        {
            Usuario user = UsuarioDAO.Usuario(u.Email);

            user.Senha = u.Senha;

            UsuarioDAO.Alterar(user);

            return RedirectToAction("AlteraUsuario", "Admin");
        }

        [HttpPost]
        public ActionResult AlteraFoto(Usuario u, HttpPostedFileBase upload)
        {
            Usuario user = UsuarioDAO.Usuario(u.Email);

            if (upload != null)
            {                
                var uploadPath = Server.MapPath("~/img/imgUsuarios");
                string caminhoArq = Path.Combine(@uploadPath, user.Nome + Path.GetExtension(upload.FileName));

                string[] extensaoPermitida = { ".gif", ".png", ".jpg",  ".jpeg"};

                for(int i = 0; i < extensaoPermitida.Length; i++)
                    if(Path.GetExtension(caminhoArq) == extensaoPermitida[i])
                    {
                        upload.SaveAs(caminhoArq);
                        break;
                    }
                user.Foto = "../img/imgUsuarios/" + user.Nome + Path.GetExtension(upload.FileName);
            }

            UsuarioDAO.Alterar(user);

            return RedirectToAction("AlteraUsuario", "Admin");
        }

        public ActionResult AlteraEmail(Usuario u)
        {
            Usuario user = UsuarioDAO.Usuario(u.Nome);

            user.Email = u.Email;

            UsuarioDAO.Alterar(user);

            return RedirectToAction("AlteraUsuario", "Admin");
        }

        public ActionResult AlteraNome(Usuario u)
        {
            Usuario user = UsuarioDAO.Usuario(u.Email);

            user.Nome = u.Nome;

            UsuarioDAO.Alterar(user);

            return RedirectToAction("AlteraUsuario", "Admin");
        }

        public ActionResult AlteraPontos(Usuario u)
        {
            Usuario user = UsuarioDAO.Usuario(u.Email);

            user.qntsPontos = u.qntsPontos;

            UsuarioDAO.Alterar(user);

            return RedirectToAction("AlteraUsuario", "Admin");
        }
    }
}