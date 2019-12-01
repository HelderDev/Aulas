using Loja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loja.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View("Login");
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult UsuarioAdicionado(Usuario u)
        {
            
            UsuarioDAO uu = new UsuarioDAO();
            uu.Inserir(u.Nome, u.Funcao);

            //uu.Listar();
        
            return View(uu.Listar());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}